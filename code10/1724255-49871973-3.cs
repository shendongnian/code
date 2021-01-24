    public static void Datas()
        {
            foreach (String line in File.ReadAllLines(@"in.txt").Skip(0))  
            { 
                string[] data = line.Split(':'); 
                string email = data[0]; 
                string phone = data[1];
        
                Info(line);
            } 
        }
    
        public static void Info(string line)
        { 
           Console.WriteLine(line);
        }
