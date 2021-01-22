    int i = 0;
    while (listBox1.Items.Count - 1 >= i)
    {
    // convert listbox object to string so we can use Trim() for remove all space(whitespace char before and after the word 
    //then check if remain character or there is nothing at all whatever whitspace char or any space
    
      if (Convert.ToString(listBox1.Items[i]).Trim() == string.Empty)
      {
       //if the line became blank after Trim() apply so the line is empty and condition is true
       listBox1.Items.RemoveAt(i);
       //decrement i because we remove line and the following line will take his place and his index number
       i -= 1;
       }
     i += 1;
    }
 
