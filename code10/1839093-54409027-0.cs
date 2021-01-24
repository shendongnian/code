        private static void MyLog(StreamWriter sw, string format, params object[] args)
        {
            if (sw == null)
                Console.WriteLine(format, args);
            else 
                sw.WriteLine(format, args);
        }
