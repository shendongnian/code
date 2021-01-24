    static void Main(string[] args)
        {
            try
            {
                Y y = new Y();
                y.MethodOfY();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.Read();
        }
