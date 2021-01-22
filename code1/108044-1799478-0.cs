    var mocks = new MockRepository();
    var time = mocks.PartialMock<TimeMachine>();
    using (mocks.Record())
    {
       Expect.Call(time.GetCurrentDateTime()).Return(new DateTime(2009, 11, 25, 12, 0, 0));
    }
    using (mocks.Playback())
    {
       Assert.AreEqual(new DateTime(2009, 11, 25), time.GetCurrentDate());
    }
                
