    public static bool IsAt { 
           get{
              var h3 = Driver.instance.FindElements(By.CSSSELECTOR("div.welcome-message>h1[title='Welcome']"));
                if (h3.Count >0)
                    return true;
                return false;
            }
         }
