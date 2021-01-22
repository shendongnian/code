    abstract class Command<T> where T : Command<T> {
       private static int counter = 1;
       private static object syncLock = new object();
  
       protected Command() {
          lock (syncLock) {
             _name = this.GetType().Name + counter++.ToString();
          }
       }
       public string Name { get { return _name; } }
       private string _name;
    }
    class Blur : Command<Blur> { }
    class Sharpen : Command<Sharpen> { }
