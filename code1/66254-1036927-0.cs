    Regex is the best choice if you consider to an iterative approach
    
     while ((input = rr.ReadLine()) != null)
    {
       foreach(var item in input.Split(' ') )
    {
        if(item.Contains("/"))
                textBox4.AppendText( item + "\r\n");
    
    }
    
    
    
      }
