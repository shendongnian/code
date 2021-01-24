                       if (Convert.ToString(row.Cells[0].Value) == 
                         txtBarcode.Text)
                             {
                              row.Cells[3].Value =Convert.ToString(1 + 
                               Convert.ToInt64(row.Cells[3].Value;
                   price = float.Parse(txtPrice.Text);
                   Quantity = float.Parse(Quantity.Text);
                   FinalPrice = price * Quantity;
                           Found = true;
                    //break;
                          }
