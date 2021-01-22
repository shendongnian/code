    [Test]
    public void FooTest()
    {
        var mock = MockRepository.GenerateMock<Test>();
    
        mock.Expect(c=>c.GetDataset2());
        
        mock.GetDataset((RandomBoolean)null);
        
    }
