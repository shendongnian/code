    var parent1 = new Mock<IParent>();
    parent1.Setup(m => m.IsValid(It.IsAny<Int32>())).Returns(true);
    IBase base1 = parent1.As<IBase>().Object; // Implement the IBase interface.
                        
    var parent2 = (new Mock<IParent>());
    parent2.Setup(m => m.IsValid(It.IsAny<Int32>())).Returns(true);
    IBase base2 = parent2.As<IBase>().Object;
   
    List<IBase> bases = new List<IBase> { base1, base2 };
    Boolean testResult = ValidateParent(bases, 123);
    Console.WriteLine(testResult);  
