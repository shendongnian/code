       public Boolean check_source_button_color()
            {
                Boolean Cond1 = false;
                try
                {
                    string headerColor = (driver.FindElement(By.LinkText("Go to regulatory source website")).GetCssValue("background-color"));
    
                    String[] hexValue = headerColor.Replace("rgba(", "").Replace(")", "").Split(',');
    
                    hexValue[0] = hexValue[0].Trim();
    
                    int hexValue1 = int.Parse(hexValue[0]);
    
                    hexValue[1] = hexValue[1].Trim();
    
                    int hexValue2 = int.Parse(hexValue[1]);
    
                    hexValue[2]  = hexValue[2].Trim();
    
                    int hexValue3 = int.Parse(hexValue[2]);
    
                    hexValue[3] = hexValue[3].Trim();
    
                    int hexValue4 = int.Parse(hexValue[3]);
    
                    String actualColor = String.Format("#{0:X2}{1:X2}{2:X2}", hexValue1, hexValue2, hexValue3);
    
                    Console.WriteLine( headerColor);
                    Console.WriteLine("actualColor is " + actualColor);
                    
                    if (actualColor.Equals("#1e95ce"))
                    {
                        Cond1 = true;
                    }
    
                    }
                catch (System.Exception ex )
                {
                    Console.WriteLine(ex.Message);
                }
                return Cond1;
            }
