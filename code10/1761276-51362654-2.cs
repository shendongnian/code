    //you don't have this one... but well, maybe other cases have
    public class SomeService
    {
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
    public class ViewModel
    {
        public string Input {get; set;}
        public string Output {get; set;}
        public ICommand command 
        {
            get
            {
                 return new RelayCommand(() =>
                 {    //it would be even better if you would use a factory or 
                      //IoC to get the service.
                      var s = SomeService();
                      s.SomeFancyMethod(new Model()
                      {
                         //properties could be mapped with an automapper.
                      });
                 });
            }
         }
     }
