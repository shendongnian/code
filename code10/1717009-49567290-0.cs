    while ((lr = fr.ReadLine()) != null)
    {
         if (m1.IsMatch(lr))
         {
             string m1_str = m1.Match(lr).Value;
             //do stuff
             continue;
         }
         if (m2.IsMatch(lr))
         {
            //same idea
         }
         
         //and so on...
    }
