          foreach (char ch in strOrderId)
            {
                if (!char.IsDigit(ch) && ch != '.')
                {
                  
                  MessageBox.Show("This is not a decimal \n");
                  return;
                }
               else
               {
               //this is a decimal value
               }
            }
