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
    [Fact]
    public void UnitTest2() {
        var data = new Data();
        data.Add("another_val1");
        data.Add("another_val2");
        var subject = new Utility();
    
        //Act
        subject.Process(data);
    
        //Assert
        // check changed data instance
    }
