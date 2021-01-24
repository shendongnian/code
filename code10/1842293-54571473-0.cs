      //If there's a popup we close it
                if (IsElementPresent(By.Id("contentPop")))
                {
                    driver.SwitchTo().Frame(driver.FindElement(By.Id("contentPop")));
                    
                    if (IsElementPresent(By.Id("ImageButton1")))
                    {
                        driver.FindElement(By.Id("ImageButton1")).Click();
                        confirmarSegundoCodigoHTML();
                    }
    
                    
                    if (IsElementPresent(By.Id("btnCerrar")) && driver.FindElement(By.Id("btnCerrar")).Displayed)
                        driver.FindElement(By.Id("btnCerrar")).Click();
    
                    driver.SwitchTo().DefaultContent();
                    driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("frame[name='area']")));
                }
