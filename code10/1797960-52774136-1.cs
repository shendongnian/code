    public static void TryOneHot()
    {
      var data = Enumerable.Range(1, 4).Select(i => new { A = $"{i}", B = $"{i}" });
      var trainData = data.Take(3).ToArray();
      var testData = data.Skip(3).ToArray();
      using (var env = new ConsoleEnvironment(seed: 1, conc: 1))
      {
        var dataView = env.CreateDataView(trainData).AssertStatic(env, c => (A: c.Text.Scalar, B: c.Text.Scalar));
        var encoderPipe = dataView.MakeNewEstimator()
          .Append(row => (
            A_OH: row.A.OneHotEncoding(),
            B_OH: row.B.OneHotEncoding()
          ));
        var encoder = encoderPipe.Fit(dataView);
        var encodedTrainingData = encoder.AsDynamic.Transform(env.CreateDataView(trainData));
        var raw = encodedTrainingData.GetColumn<float[]>(env, "A_OH").ToArray();
        var encodedTestData = encoder.AsDynamic.Transform(env.CreateDataView(testData));
        var rawUnseen = encodedTestData.GetColumn<float[]>(env, "A_OH").ToArray();
      }
    }
