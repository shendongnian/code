       public interface IShellView
        {
            
        }
        public class View:IShellView
        {
        }
    
        //public class SomeOtherClass
        //{
        //    static void Main()
        //    {
        //        IShellView someView = new View();
        //        //calling code 
        //        ShellPresenter sp = new ShellPresenter();
    
        //        //Why is this allowed? 
        //        sp.View = someView;//setting a private set outside the ShellPresenter class is NOT allowed.
        //    }
        //}
    
        public class ShellPresenter
        {
            public ShellPresenter()
            {
            }
            public ShellPresenter(IShellView view)
            {
                View = view;
    
            }
            static void Main()
            {
                IShellView someView = new View();
                //calling code 
                ShellPresenter sp = new ShellPresenter();
    
                //Why is this allowed? 
                sp.View = someView;//because now its within the class
            }
            public IShellView View { get; private set; }
        } 
