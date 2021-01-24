    class MySettings
    {
        bool AreSettingsValid(IMyLogic myLogic){
            return myLogic.GetSetting("Setting1") != null &&
                   myLogic.GetSetting("Setting2") != null;
        }
    }
    class MyLogic: IMyLogic {
        string GetSetting(string key){
            return (string) Properties.Settings.Default[key];
        }
    }
    [TestClass]
    class MyLogicTest 
    {
        [TestMethod]
        void MyLogic_AreSettingsValidIsTrue_WhenValuesAreSet(){
            var mockMyLogic = Mock<IMyLogic>();
            
            mockMyLogic.Setup(m=>
                m.GetSetting(It.IsAny<string())).Returns("something");
            var mySettings = new MySettings();
            Assert(true, mySettings.AreSettingsValid(myLogic.Object));
        }
    }
