    [Fact]
    public void BuildAndClassify()
    {
      var classifier = BuildClassifier();
      AssertCanClassify(classifier);
    }
    
    [Fact]
    public void DeserializeAndClassify()
    {
      BuildClassifier().Serialize("test.weka");
      var classifier = Classifier.Deserialize<LinearRegression>("test.weka");
      AssertCanClassify(classifier);
    }
    
    private static void AssertCanClassify(LinearRegression classifier)
    {
      var result = classifier.Classify(-402, -1);
      Assert.InRange(result, 255.8d, 255.9d);
    }
    
    private static LinearRegression BuildClassifier()
    {
      var trainingSet = new TrainingSet("attribute1", "attribute2", "class")
    	.AddExample(-173, 3, -31)
    	.AddExample(-901, 1, 807)
    	.AddExample(-901, 1, 807)
    	.AddExample(-94, -2, -86);
    
      return Classifier.Build<LinearRegression>(trainingSet);
    }
