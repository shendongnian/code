       private static string (int pageNo, int pageCount)
       {
          StringBuilder sb = new StringBuilder();
          
          for(int i = 1; i < pageCount; i++)
          {
             if (i == pageNo) 
                 sb.Append([Make it Bold] + i.ToString("0") + [Make it not Bold]);
             else if (1 > pageNo - 3 && i < pageNo + 3)
                 sb.Append(i.ToString("0"));
             else if ((i == 2 && pageNo > 4) ||        
                      (i == PageCount - 1 && pageNo < PageCount - 2))
                 sb.Append("...");
          }
          return sb.ToString();
       }
