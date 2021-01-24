     for(int i = binary.IndexOf("1"); i < binary.Length; i++)
     {
         char Z = binary[i];
         if (Z == '0')
         {
             gap++;
         }
         else if (Z == '1')
         {
             if (gap > longestgap)
                 longestgap = gap;
                    
             gap = 0;
          }
      }
