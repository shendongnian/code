    class Program
    {
        static void Main(string[] args)
        {
        }
        async Task<int> GetVAsync()
        {
            try
            {
            }
            catch
            {
                //gives error CS1985: Cannot await in the body of a catch clause
                await Task.Delay(1000); 
            }            
            return 3;
        }
    }
