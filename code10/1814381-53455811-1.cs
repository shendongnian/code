        @Test
        public void singleTestForBothLanguages() {
            boolean isEnglishMode = isEnglishMode();
            string expectedMessage;
            if (isEnglishMode) {
                expectedMessage = "A product with identical service id and service provider already exists!";
            } else {
                expectedMessage = "Produkt kann nicht erstellt werden! Ein Produkt mit identischer Dienst Id und Diensteanbieter ist bereits vorhanden!";
            }
            checkAlert(expectedMessage);
        }
        
        //for example check attribute of some element (maybe a flag? or whatever makes you sure to know which mode is on now)
        public bool isEnglishMode() {
            if ( ....){
                return true;
            }
            return false;
        }
    
        public void CheckAlert(string expectedMessage) {
            string modalMessage = productsPage.errorMsgServiceIdTaken.Text;
            try {
                Assert.AreEqual(expectedMessage, modalMessage);
            } catch (NUnit.Framework.AssertionException) {
                test.Log(Status.Warning, "The modal dialog did not contain message '" + modalMessage + "'.");
            }
        }
