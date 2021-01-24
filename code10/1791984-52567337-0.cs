    internal static async Task<PredictionModel<ClassificationData, ClassPrediction>> PredictAsync(
        string modelPath,
        IEnumerable<ClassificationData> predicts = null,
        PredictionModel<ClassificationData, ClassPrediction> model = null)
    {
        if (model == null)
        {
            new LightGbmArguments();
            model = await PredictionModel.ReadAsync<ClassificationData, ClassPrediction>(modelPath);
        }
        if (predicts == null) // do we have input to predict a result?
            return model;
        // Use the model to predict the positive or negative sentiment of the data.
        IEnumerable<ClassPrediction> predictions = model.Predict(predicts);
        Console.WriteLine();
        Console.WriteLine("Classification Predictions");
        Console.WriteLine("--------------------------");
        // Builds pairs of (sentiment, prediction)
        IEnumerable<(ClassificationData sentiment, ClassPrediction prediction)> sentimentsAndPredictions =
            predicts.Zip(predictions, (sentiment, prediction) => (sentiment, prediction));
        if (!model.TryGetScoreLabelNames(out var scoreClassNames))
            throw new Exception("Can't get score classes");
        foreach (var (sentiment, prediction) in sentimentsAndPredictions)
        {
            string textDisplay = sentiment.Text;
            if (textDisplay.Length > 80)
                textDisplay = textDisplay.Substring(0, 75) + "...";
            string predictedClass = prediction.Class;
            Console.WriteLine("Prediction: {0}-{1} | Test: '{2}', Scores:",
                prediction.Class, predictedClass, textDisplay);
            for(var l = 0; l < prediction.Score.Length; ++l)
            {
                Console.Write($"  {l}({scoreClassNames[l]})={prediction.Score[l]}");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        Console.WriteLine();
        return model;
    }
}
