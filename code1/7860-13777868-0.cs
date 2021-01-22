          if (String.IsNullOrEmpty(precision))
          {
            if (size < 10)
            {
               precision = "2";
            }
            else if (size < 100)
            {
                precision = "1";
            }
            else
            {
               precision = "0";
            }
          }
