    //you don't have this one... but well, maybe other cases have
    public class SomeService : ISomeService
    {
        //member of ISomeService
        public void SomeFancyMethod(Model model)
        {
            //do stuff..
        }
    }
    public class Model //might be database, or domain model.
    {
       public string Input { get; set; }
       public string Output { get; set; }
    }
