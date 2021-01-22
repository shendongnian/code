    abstract class Command {
       private static Dictionary<Type, int> counter = new Dictionary<Type, int>();
       private static object syncLock = new object();
 
       protected Command() {
          Type t = this.GetType();
          lock (syncLock) {
             if (!counter.ContainsKey(t)) {
                counter.Add(t, 0);
             }
             _name = t.Name + counter[t]++.ToString();
          }
       }
       public string Name { get { return _name; } }
       private string _name;
    }
    class Blur : Command { }
    class Sharpen : Command { }
