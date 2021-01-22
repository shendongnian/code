    public IEnumerable<Control> Get (object o)  
    {  
        if (o is System.Windows.Forms.Control)  
        {  
            System.Windows.Forms.Control f =(System.Windows.Forms.Control)o;  
            foreach(System.Windows.Forms.Control c in f.Controls)  
            {  
                yield return c;
                foreach(System.Windows.Forms.Control c2 in Get(c))  
                {
                    yield return c2;
                }
            }  
        }  
    }
