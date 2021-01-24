    public static class SomeClassWithEventDeclaration
    {
        public event EventHandler<SomeClassType> Completed;
    }
    public class YourClassWithWork
    {
        public void Work()
        {
            SomeClassWithEventDeclaration.Completed += (sender, data) =>
            { 
               CheckTheData(data);
               HideProgressBar();
            };
        }
        public void MethodWithDataProcessing()
        {
            try
            {
               //Your processing
               SomeClassWithEventDeclaration.Completed.Invoke(someData);
            }
            catch(Exception ex)
            {
               //SomeClassWithEventDeclaration.Completed.Invoke(someErrorData);
            }
        }
    }
