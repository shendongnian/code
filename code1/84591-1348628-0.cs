    [TestMethod]
    public void MyTest()
    {
        var deviceControlForm = MockRepository.GenerateStub<IDeviceControlForm>();
        var data = MockRepository.GenerateStub<IDataAccess>();
        var mockCallMonitor = MockRepository.GenerateStub<ICallMonitor>();
        var deviceMediator = new DeviceMediator(deviceControlForm, data);
        deviceMediator.CallMonitor = mockCallMonitor;
        // The rest of the test...
    }
