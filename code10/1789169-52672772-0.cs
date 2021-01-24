     [TestMethod]
        public void SearchUser()
        {
            var  credentials = new UserCredentials("domain", "UID", "PWD");
            var result = Impersonation.RunAsUser(credentials, LogonType.NewCredentials, () =>
            {
                //CODE INSDIE THIS BLOCK WILL RUN UNDER THE ID OF ANOTHER USER 
                dynamic actualResult = controller.SearchUser();
                //Assert
                Assert.IsNotNull(actualResult);
                return actualResult;
            });
        }
