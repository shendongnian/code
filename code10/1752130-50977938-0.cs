    var parent1 = new Mock<IParent>();
    parent1.Setup(m => m.IsValid(It.IsAny<Int32>())).Returns(true);
    
    var parent2 = new Mock<IParent>();
    parent2.Setup(m => m.IsValid(It.IsAny<Int32>())).Returns(true);
   
    List<IParent> parents = new List<IParent> { parent1.Object, parent2.Object };
    
    Boolean testResult = ValidateParent(parents, 123);
    
