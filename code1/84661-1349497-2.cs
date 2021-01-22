        [TestMethod]
        public void TestHandleIncomingCall()
        {
            //Arrange
            callMonitor.InCall = true;
            // This is the magic.  When Hangup is called I am able to set
            // the stub's InCall value to false.
            callMonitor.Expect(x => x.Hangup()).Callback(() => WhenCalled(invocation =>
                                                           {
                                                               callMonitor.InCall = false;
                                                           });
            List<PhoneContact> whiteList = FillTestObjects.GetSingleEntryWhiteList();
            data.Expect(x => x.GetWhiteListData()).Return(whiteList);
            const string invalidPhoneNumber = "123";
            //Act
            deviceMediator.HandleIncomingCall(invalidPhoneNumber);
            //Assert
            Assert.IsFalse(callMonitor.InCall);
        }
