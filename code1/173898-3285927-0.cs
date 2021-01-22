    [Test]
    public void FooTest()
    {
        MockRepository mock = new MockRepository();
        Test c = mock.PartialMock<Test>();
    
        using (mock.Record())
        {
            Expect.Call(c.GetDataset2());
        }
        using (mock.Playback())
        {
            result = c.GetDataset((RandomBoolean)null);
        }
    }
