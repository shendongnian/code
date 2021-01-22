    using System.Text;
    
    namespace ConsoleApplication1
    {
        //I've made this class private to demonstrate that the SaveToDatabase cannot have any knowledge of this Program class.
        class Program
        {
            static void Main(string[] args)
            {
                SaveToDatabase sd = new SaveToDatabase();
    
    //Please note, that although NotifyIfComplete() takes a string parameter, we do not declare it - all we want to do is tell C# where the method is so it can be referenced later - we will pass the paramater later.
                NotifyDelegateWithMessage notifyDelegateWithMessage = new NotifyDelegateWithMessage(NotifyIfComplete);
                sd.Start(notifyDelegateWithMessage );
    
                Console.ReadKey();
            }
    
            private static void NotifyIfComplete(string message)
            {
                Console.WriteLine(message);
            }
        }
        
    
        public class SaveToDatabase
        {
            public void Start(NotifyDelegateWithMessage nd)
            {
                //To simulate a saving fail or success, I'm just going to check the current time (well, the seconds) and store the value as variable.
                string message = string.Empty;
                if (DateTime.Now.Second > 30)
                    message = "Saved";
                else
                    message = "Failed";
    
                //It is at this point we pass the parameter to our method.
                nd.Invoke(message);
            }
        }
    
        public delegate void NotifyDelegateWithMessage(string message);
    }
