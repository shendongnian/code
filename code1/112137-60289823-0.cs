namespace Test
{
  class Foreach
  {
    string[] names = new[] { "ABC", "MNL", "XYZ" };
    void Method1()
    {
      List<User> list = new List<User>();
      User u;
      foreach (string s in names)
      {
        u = new User();
        u.Name = s;
        list.Add(u);
      }
    }
    void Method2()
    {
      List<User> list = new List<User>();
      foreach (string s in names)
      {
        User u = new User();
        u.Name = s;
        list.Add(u);
      }
    }
  }
  public class User { public string Name; }
}
I verified the CIL but it is not identical.
[![enter image description here][1]][1]
So I prepared something what I wanted to be much better test.
namespace Test
{
  class Loop
  { 
    public TimeSpan method1 = new TimeSpan();
    public TimeSpan method2 = new TimeSpan();
    Stopwatch sw = new Stopwatch();
    public void Method1()
    {
      sw.Restart();
      C c;
      C c1;
      C c2;
      C c3;
      C c4;
      int i = 1000;
      while (i-- > 0)
      {
        c = new C();
        c1 = new C();
        c2 = new C();
        c3 = new C();
        c4 = new C();        
      }
      sw.Stop();
      method1 = method1.Add(sw.Elapsed);
    }
    public void Method2()
    {
      sw.Restart();
      int i = 1000;
      while (i-- > 0)
      {
        var c = new C();
        var c1 = new C();
        var c2 = new C();
        var c3 = new C();
        var c4 = new C();
      }
      sw.Stop();
      method2 = method2.Add(sw.Elapsed);
    }
  }
  class C { }
}
Also in this case 2nd method was always winning but then I verified the CIL finding no difference.
[![enter image description here][2]][2]
I am not CIL-reading guru but I see no decleration issue. As was already pointed out declaration is not allocation so there is no performance penalty on it.
### Test
namespace Test
{
  class Foreach
  {
    string[] names = new[] { "ABC", "MNL", "XYZ" };
    public TimeSpan method1 = new TimeSpan();
    public TimeSpan method2 = new TimeSpan();
    Stopwatch sw = new Stopwatch();
    void Method1()
    {
      sw.Restart();
      List<User> list = new List<User>();
      User u;
      foreach (string s in names)
      {
        u = new User();
        u.Name = s;
        list.Add(u);
      }
      sw.Stop();
      method1 = method1.Add(sw.Elapsed);
    }
    void Method2()
    {
      sw.Restart();
      List<User> list = new List<User>();
      foreach (string s in names)
      {
        User u = new User();
        u.Name = s;
        list.Add(u);
      }
      sw.Stop();
      method2 = method2.Add(sw.Elapsed);
    }
  }
  public class User { public string Name; }
  [1]: https://i.stack.imgur.com/biVF8.png
  [2]: https://i.stack.imgur.com/7rFmo.png
