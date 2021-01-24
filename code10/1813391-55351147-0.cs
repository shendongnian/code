            /* Safari Hack */
            int x;
            int y;
            try
            {
                x = element.Location.X;
            }
            catch (Exception)
            {
                x = ((OpenQA.Selenium.Remote.RemoteWebElement)element).LocationOnScreenOnceScrolledIntoView.X;
            }
            try
            {
                y = element.Location.Y;
            }
            catch (Exception)
            {
                y = ((OpenQA.Selenium.Remote.RemoteWebElement)element).LocationOnScreenOnceScrolledIntoView.Y;
            }
