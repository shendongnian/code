    [Fact]
    public void UnitTest1() {
        //Arrrange
        var data = new Data();
        data.Add("val1");
        var subject = new Utility();
    
        //Act
        subject.Process(data);
    
        //Assert
        // check changed data instance
    }
