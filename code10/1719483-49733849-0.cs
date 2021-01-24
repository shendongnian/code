                IWebElement messageContent = Driver.Instance.FindElement(By.Id("emailMessageContent"));
                Actions actions = new Actions(Driver.Instance);
                actions.MoveToElement(messageContent);
                actions.Click();
                actions.SendKeys("This is a test");
                actions.Build().Perform();
