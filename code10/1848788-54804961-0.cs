     IWebElement classes = driver.FindElement(By.CssSelector("span#select2-ctl00_ctl00_BaseRightContent_MainRightContent_EditMachineDetails_MachineClassList-container"));
                classes.Click();
                //IWebElement classclickelement = driver.FindElement(By.Name(registerLiebherrMachineParam.MachineClass));
                //classclickelement.Click();
                IWebElement classestextbox = driver.FindElement(By.CssSelector("input[class='select2-search__field'][role='textbox']"));
                classestextbox.SendKeys(registerLiebherrMachineParam.MachineClass);            
                IWebElement clickgivenclass = driver.FindElement(By.CssSelector($"li[class='select2-results__option select2-results__option--highlighted'][value='{registerLiebherrMachineParam.MachineClass}']"));
                clickgivenclass.Click();
