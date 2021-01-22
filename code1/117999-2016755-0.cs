    public interface IMyObject
    {
         void DoSomething();
    }
    public class MyFriendClass
    {
         IMyObject GetObject() { return new MyObject(); }
         class MyObject : IMyObject
         {
              public void DoSomething() { // ... Do something here
              }
         }
    }
