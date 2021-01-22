     public string FormatPostingDate(object obj)
     {
         if (obj != null && obj.ToString() != string.Empty)
         {
             DateTime postingDate = Convert.ToDateTime(obj);
             return string.Format("{0:MM/dd/yyyy}", postingDate);
         }
         return string.Empty;
     }
