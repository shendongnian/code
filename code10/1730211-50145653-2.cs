    using System;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Web.Services;
    using System.Web.UI;
    
    namespace WebApplication3
    {
        public partial class WebForm1 : Page
        {
         
            protected void Page_Load(object sender, EventArgs e) { }
            [WebMethod]
            public static async Task<string> GetFunctionTiming()
            {
                Debug.WriteLine("Shim function called.");
                string returnString = "Start time: " + DateTime.Now.ToString();
    
                // Here's the idiomatic shim that allows async calls from PageMethods
                string myParameter = "\nEnd time: "; // Some parameter we're going to pass to the business logic
                Task<string> myTask = Task.Run( () => BusinessLogicAsync(myParameter) ); // Avoid a deadlock problem by forcing the task onto the threadpool
                string myResult = await myTask.ConfigureAwait(false); // Force the continuation onto the current (ASP.NET) context
                Debug.WriteLine("Shim function completed.  Returning result "+myResult+" to PageMethods call on web site...");
                return returnString + myResult;
            }
            // This takes the place of some complex business logic that may nest deeper async calls
            private static async Task<string> BusinessLogicAsync(string input)
            {
                Debug.WriteLine("Invoking business logic.");
                string returnValue = await DeeperBusinessLogicAsync();
                Debug.WriteLine("Business logic completed.");
                return input+returnValue;
            }
    
            // Here's a simulated deeper async call
            private static async Task<string> DeeperBusinessLogicAsync()
            {
                Debug.WriteLine("Invoking deeper business logic.");
                await Task.Delay(1000); // This simulates a long-running async process
                Debug.WriteLine("Deeper business logic completed.");
                return DateTime.Now.ToString();
            }
        }
    }
