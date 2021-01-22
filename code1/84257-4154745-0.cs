       public static void Write(string s)
       {
           // thread 1 is interrupted here <=
           lock (_lock)
           {
               _writer.Write(s);
           }
       }
