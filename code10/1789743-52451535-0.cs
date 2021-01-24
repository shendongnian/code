       public static int random_except_list(List<int> x)
       {
            Random r = new Random();
            int result = 0;
            while (true)
            {
                result = r.Next(1, 10);
                if (!x.Contains(result))
                    return result;                
            }
        }
