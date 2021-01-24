    [Test(Author = "Michele Delle Donne"), Description("")]
        [TestCaseSource("TC_XXXX_XXXXXXXXXX"), Category("XXXXX")]      
        public void DA_ACOM(Type testClass, string environment, string user, string pwd, string result)
        {           
            Services.ObjBase automationTest = null;
        
            object[] args = new object[] { Settings_Default.browser, environment, testClass.ToString(), testClass.ToString(), result };
            automationTest = (Services.ObjBase)Activator.CreateInstance(testClass, args);
            if (automationTest != null)
            {
                automationTest.ExecuteAutomation(environment, user, pwd);
            }
            Thread.Sleep(TimeSpan.FromSeconds(1));
            automationTest.End();       
        }
