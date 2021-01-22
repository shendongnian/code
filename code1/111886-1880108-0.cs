        public static void testThread()
        {
            throw new Exception("oh god it's broken");
        }
        static void Main(string[] args)
        {
            try
            {
                Thread thread = new Thread(testThread);
                thread.Start();
                Console.ReadKey(); //Just to make sure we don't get out of the try-catch too soon
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
