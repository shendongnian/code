        
    [TestMethod]
    public void TestMethod1()
    {
        var model = new Person();
        var validationResultList = new List<ValidationResult>();
    
    
        bool b1 = Validator.TryValidateObject(model, new ValidationContext(model), validationResultList);
    }
