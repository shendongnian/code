public void SomeMethod(int param)
{
#ifdef NET_1_1
 // Need to use Helper to Get Foo under .NET 1.1
  Foo foo = Helper.GetFooByParam(param);
#elseif NET_2_0 || NET_3_5
 // .NET 2.0 and above can use preferred  method. 
  var foo =  new Foo { Prop = param }; 
  foo.LoadByParam();  
#endif 
  foo.Bar();
}
#ifdef NET_3_5
// A method that is only available under .NET 3.5 
public int[] GetWithFilter(Func<int, bool> Filter)
{ 
  // some code here
}
#endif 
