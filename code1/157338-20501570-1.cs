     public string FormatPostingDate(string str)
     {
         if (str != null && str != string.Empty)
         {
             DateTime postingDate = Convert.ToDateTime(str);
             return string.Format("{0:MM/dd/yyyy}", postingDate);
         }
         return string.Empty;
     }
