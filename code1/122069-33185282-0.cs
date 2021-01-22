     foreach (var item in listBox1.Items.Cast<string>().ToList())
     {
         string removelistitem = "OBJECT";
         if (item.Contains(removelistitem))
         {
            listBox1.Items.Remove(item);
         }
     }
 
