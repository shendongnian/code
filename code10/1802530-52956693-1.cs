    using (StreamReader file = new StreamReader("Score_4.dat"))            
    {   
        while ((line = file.ReadLine()) != null && line.Length > 10)
        {                    
            line.Trim();
            string[] parts;
            parts = line.Split(' ');
            MyItem item = new Item(Int32.Parse(parts[0]),Int32.Parse(parts[1]),Float.Parse(parts[2]));
            mylist.Add(item);
            i++; 
        }
    }
