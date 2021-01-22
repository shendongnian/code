      public static void RemoveDuplicates<T>(IList<T> list )
      {
         if (list == null)
         {
            return;
         }
         int i = 1;
         while(i<list.Count)
         {
            int j = 0;
            bool remove = false;
            while (j < i && !remove)
            {
               if (list[i].Equals(list[j]))
               {
                  remove = true;
               }
               j++;
            }
            if (remove)
            {
               list.RemoveAt(i);
            }
            else
            {
               i++;
            }
         }  
      }
