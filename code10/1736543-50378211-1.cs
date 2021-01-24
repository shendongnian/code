    namespace My.UiLayer
    {
        public class MyUiClass
        {
            try
            {
                BusinessLogicClass blc = new BusinessLogicClass();
                blc.WriteCustomers(string filePath, IEnumerable<Customer> customers);
            }
            catch (IOException e)
            {
              // Read from 'e' and display description in your UI here
            }
        }
    }
