    public class Base
    {
      public Object model;
      protected Service service;
    
      protected bool Create()
      {
              try
            {
                Model = Service.Create(Model);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
      }
    }
    public class Example1 : Base
    {
      public Example1() //Assign specifics in constructor
      {
        model = model1;
        service = service1;
      }
    }
    public class Example2 : Base
    {
      public Example2() //Assign specifics in constructor
      {
        model = model2;
        service = service2;
      }
    }
