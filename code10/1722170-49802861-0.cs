    //Suppose those are posts with tf-idf weights
    double[][] inputs =
    {
      new[] { 3.0, 1.0 },
      new[] { 7.0, 1.0 },
      new[] { 3.0, 1.0 },
      new[] { 3.0, 2.0 },
      new[] { 6.0, 1.0 },
    };
    //amount of likes each corresponding post scored
    double[] outputs = {2.0, 3.0, 4.0, 11.0, 6.0};
    //Using FanChenLinSupportVectorRegression<Kernel>
    var model = new FanChenLinSupportVectorRegression<Gaussian>();
    //Train model and feed it with tf-idf of each post and corresponding like amount
    var svm = model.Learn(inputs, outputs);
    //Run a sample tf-idf input to get a prediction
    double result = svm.Score(new double[] { 2.0,6.0});
