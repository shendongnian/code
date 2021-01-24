    [Fact]
    public void UnitTest1() {
        //Arrrange
        var data = new Data();
        data.Add("val1");
        var subject = new Utility(data);
    
        //Act
        subject.Process();
    
        //Assert
        // check changed data instance
    }
