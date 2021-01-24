       public string TimeAsText {
             get {
                  return Hours.ToString().PadLeft(2, '0') + ":" + ((int)(Math.Round(Minutes / 5.0)*5)).ToString().PadLeft(2, '0');
             }
         }
