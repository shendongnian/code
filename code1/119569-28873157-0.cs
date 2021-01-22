    public static void AreEqualXYZ_UsageExample()
    {
    	AreEqualXYZ(actual: class1UnderTest, 
    		expectedBoolExample: true, 
    		class2Assert: class2 => Assert.IsNotNull(class2), 
    		class3Assert: class3 => Assert.AreEqual(42, class3.AnswerToEverything));
    }
    
    public static void AreEqualXYZ(Class1 actual,
    	bool expectedBoolExample,
    	Action<Class2> class2Assert,
    	Action<Class3> class3Assert)
    {
    	Assert.AreEqual(actual.BoolExample, expectedBoolExample);
    
    	class2Assert(actual.Class2Property);
    	class3Assert(actual.Class3Property);
    }
