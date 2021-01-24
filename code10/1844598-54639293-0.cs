    public string TimeAsText {
         get {
              return Hours.ToString().PadLeft(2, '0') + ":" + ((Minutes / 5)*5).ToString().PadLeft(2, '0');
         }
     }
