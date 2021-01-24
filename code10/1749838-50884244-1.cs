    public class Program
    {
        public void Main()
        {
            try
            {
                using (var obj = MyObj.Create())
                {
                    var message = obj.ReadMessage();
                    Console.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                // Everything is already cleaned up by the using statement.
                Console.WriteLine(ex.Message);
            }
        }
    }
