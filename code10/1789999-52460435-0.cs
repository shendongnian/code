    var pipeline = new LearningPipeline();
    var data = new List<IrisData>() {
        new IrisData { SepalLength = 1f, SepalWidth = 1f, PetalLength=0.3f, PetalWidth=5.1f, Label=1},
        new IrisData { SepalLength = 1f, SepalWidth = 1f, PetalLength=0.3f, PetalWidth=5.1f, Label=1},
        new IrisData { SepalLength = 1.2f, SepalWidth = 0.5f, PetalLength=0.3f, PetalWidth=5.1f, Label=0}
    };
    var collection = CollectionDataSource.Create(data);
    pipeline.Add(collection);
    pipeline.Add(new ColumnConcatenator(outputColumn: "Features",
        "SepalLength", "SepalWidth", "PetalLength", "PetalWidth"));
    pipeline.Add(new StochasticDualCoordinateAscentClassifier());
    var model = pipeline.Train<IrisData, IrisPrediction>();
