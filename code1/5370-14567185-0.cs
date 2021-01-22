            string s = string.Empty;
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("Beginning String + at " + DateTime.Now.ToString());
            for (int i = 0; i <= 50000; i++)
            {
                s = s + 'A';
            }
            Console.WriteLine("Finished String + at " + DateTime.Now.ToString());
            Console.WriteLine();
            Console.WriteLine("Beginning String + at " + DateTime.Now.ToString());
            for (int i = 0; i <= 200000; i++)
            {
                s = s + 'A';
            }
            Console.WriteLine("Finished String + at " + DateTime.Now.ToString());
            Console.WriteLine();
            Console.WriteLine("Beginning Sb append at " + DateTime.Now.ToString());
            for (int i = 0; i <= 1000000; i++)
            {
                sb.Append("A");
            }
            Console.WriteLine("Finished Sb append at " + DateTime.Now.ToString());
            Console.ReadLine();
