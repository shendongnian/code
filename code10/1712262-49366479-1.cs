    class MyLogic
    {
        bool AreSettingsValid(IMySettings mySettings){
            return mySettings.GetSetting("Setting1") != null &&
                   mySettings.GetSetting("Setting2") != null;
        }
    }
    class MySettings: IMySettings {
        string GetSetting(string key){
            return (string) Properties.Settings.Default[key];
        }
    }
    [TestClass]
    class MyLogicTest 
    {
        [TestMethod]
        void MyLogic_AreSettingsValidIsTrue_WhenValuesAreSet(){
            var mockMySettings = Mock<IMySettings>();
            
            mockMySettings.Setup(m=>
                m.GetSetting(It.IsAny<string())).Returns("something");
            var myLogic = new MyLogic();
            Assert(true, myLogic.AreSettingsValid(mySettings.Object));
        }
    }
