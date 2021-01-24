    public class MyFirstTest
        {
            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            [Test]
            public void myFirstTest()
                {
                driver.Navigate().GoToUrl("https://softuni.bg");
                driver.FindElement(By.LinkText("Login")).Click();
                //invalid scenario
                IWebElement userName = driver.FindElement(By.Name("username"));
                userName.Clear();
                userName.SendKeys("username");
                IWebElement userPass = driver.FindElement(By.Name("password"));
                userPass.Clear();
                userPass.SendKeys("password"); TimeSpan.FromSeconds(10);
                driver.FindElement(By.LinkText("Ok")).Click();
    
                driver.FindElement(By.XPath("/html/body/main/div[2]/div/div[2]/div[1]/form/input[2]")).Submit(); TimeSpan.FromSeconds(10);
                IWebElement ErrMessage = driver.FindElement(By.ClassName("validation-summary-errors"));
                Console.Write(ErrMessage.Text);
                Assert.IsTrue(ErrMessage.Text.Contains("Wrong username or password"));
                //valid secenario
                userName.Clear();
                userName.SendKeys("username");
                userPass.Clear();
                userPass.SendKeys("password");
                driver.FindElement(By.XPath("//form/input[2]")).Submit(); 
                TimeSpan.FromSeconds(10);
                int count = driver.FindElements(By.ClassName("validation-summary-errors")).Count;
                Assert.IsTrue(count==0);
                driver.Close();
                driver.Quit();
             }
       }
