    public class MyController: Controller
    {
       // automatically passed by IoC container
       public MyController(IUserDataStorage<MyObject> objectData)
       {
       }
    }
