    List<string> temp = new List<string>();
        
        foreach (string item in listBox1.Items)
        {
            string removelistitem = "OBJECT";
            if(item.Contains(removelistitem))
            {
                temp.Items.Add(item);
             }
         }
        
        foreach(string item in temp)
        {
           listBox1.Items.Remove(item);
        }
