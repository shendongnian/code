     class Program
        {
            static void Main()
            {
                StringBuilder sb = new StringBuilder();
                Console.WriteLine(sb.Capacity); //16
    
                for (int i = 0; i < 50; i++) 
                    sb.Append(i + ",");
    
                Console.WriteLine(sb.Capacity); //256
    
                sb = new StringBuilder();
                Console.WriteLine(sb.Capacity); //16
            }
        }
