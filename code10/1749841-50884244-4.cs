    public class Program
    {
        public void Main()
        {
            try
            {
                using (var obj = MyObj.Create())
                {
                    // everything is already in a valid state.
                    var message = obj.ReadMessage();
                    Console.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                // If the factory succeeded, the using statement did the cleanup.
                // if the factory failed, the factory took care of the cleanup.
                Console.WriteLine(ex.Message);
            }
        }
    }
