    var data = new List<IrisData>() {
        new IrisData { SepalLength = 1f, SepalWidth = 1f ,PetalLength=0.3f, PetalWidth=5.1f, Label=1},
        new IrisData { SepalLength = 1f, SepalWidth = 1f ,PetalLength=0.3f, PetalWidth=5.1f, Label=1},
        new IrisData { SepalLength = 1.2f, SepalWidth = 0.5f ,PetalLength=0.3f, PetalWidth=5.1f, Label=0}
    };
    var collection = CollectionDataSource.Create(data);
    pipeline.Add(collection);
    pipeline.Add(new ColumnConcatenator(outputColumn: "Features",
        "SepalLength", "SepalWidth", "PetalLength", "PetalWidth"));
    pipeline.Add(new StochasticDualCoordinateAscentClassifier());
    PredictionModel<IrisData, IrisPrediction> model = pipeline.Train<IrisData, IrisPrediction>();
    IrisPrediction prediction = model.Predict(new IrisData()
    {
        SepalLength = 3.3f,
        SepalWidth = 1.6f,
        PetalLength = 0.2f,
        PetalWidth = 5.1f,
    });
    pipeline = new LearningPipeline();
    collection = CollectionDataSource.Create(data.AsEnumerable());
    pipeline.Add(collection);
    pipeline.Add(new ColumnConcatenator(outputColumn: "Features",
        "SepalLength", "SepalWidth", "PetalLength", "PetalWidth"));
    pipeline.Add(new StochasticDualCoordinateAscentClassifier());
    model = pipeline.Train<IrisData, IrisPrediction>();
