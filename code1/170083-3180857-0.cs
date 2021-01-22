    public class MyClass {
      [Cache, timeToLive=60]
      string getName(string id, string location){
        return ExpensiveCall(id, location);
      }
    }
    
    // ...
    MyClass c = new MyClass();
    string name = c.getName("id", "location");
    string name_again = c.getName("id", "location");
