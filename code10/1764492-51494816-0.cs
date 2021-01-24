            //Expected attachment filename needs to be specified here.
            var expectedFileName = "1177A149.PNG";
            //This list will hold all the available attachment section details
            IList<IWebElement> attachmentList = _driver.FindElements(By.ClassName("comment-box"));
            foreach(var element in attachmentList)
            {
                var attachmentFilename = element.FindElement(By.XPath(".//div[@class='username']")).Text;
                if(attachmentFilename == expectedFileName)
                {
                    //If the actual file name and expected file name matches, then corresponding download link will be clicked
                    element.FindElement(By.XPath(".//a")).Click();
                }
                
            }
