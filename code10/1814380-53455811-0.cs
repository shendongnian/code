        @Test
        public void EnglishTest() {
            //implement logic that will start your app in English mode
            startAppInEnglishMode();
            String expectedMessage = "A product with identical service id and service provider already exists!";
            checkAlert(expectedMessage);
        }
    
        @Test
        public void GermanTest() {
            //implement logic that will start your app in German mode
            startAppInGermanMode();
            String expectedMessage = "Produkt kann nicht erstellt werden! Ein Produkt mit identischer Dienst Id und Diensteanbieter ist bereits vorhanden!";
            checkAlert(expectedMessage);
        } 
        public void CheckAlert(string expectedMessage) {
            string modalMessage = productsPage.errorMsgServiceIdTaken.Text;
            try {
                Assert.AreEqual(expectedMessage, modalMessage);
            } catch (NUnit.Framework.AssertionException) {
                test.Log(Status.Warning, "The modal dialog did not contain message '" + modalMessage + "'.");
            }
        }
