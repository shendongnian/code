    var result = dbContext.Model1s.Select(model1 => new
    {
         SomeProperty = model1.PropertyA,
         SomeOtherProperty = model1.Model2.PropertyB,
         MyX = model1.Model2.PropertyC,
         MyY = model2.PropertyD,
    });
