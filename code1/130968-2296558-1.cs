    using System.Linq;
    ...
    foreach (ClsPC pc in iclsobj.GetPC()) 
    {     
        if (listBox1.Items.Count == 0) 
        { 
            listBox1.Items.Add(pc.IPAddress); 
        } 
        else 
        { 
            if (!listBox1.Items.Any(i => String.Compare(i.ToString(), pc.IPAddress, true) == 0))
            {
               listBox1.Items.Add(pc.IPAddress); 
            }
       } 
    }
