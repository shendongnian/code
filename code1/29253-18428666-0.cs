    char[] c = txtGetCustomerId.Text.ToCharArray();
    bool IsDigi = true;
    
    for (int i = 0; i < c.Length; i++)
         {
           if (c[i] < '0' || c[i] > '9')
          { IsDigi = false; }
         }
     if (IsDigi)
        { 
         // do something
        }
