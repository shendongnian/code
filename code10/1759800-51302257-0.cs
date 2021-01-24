    You can use assert on you verification point, if assert conditions is not matching assert will throw exception :
     
    String expectedTitle = "Utilities from Go Compare";
    
    // 1st Way
    bool isTrue= webDriver.Title.Contains(expectedTitle);
    Assert.IsTrue(isTrue);
    
    OR 
    
    // 2nd Way
    Assert.Contains(expectedTitle,webDriver.Title);
