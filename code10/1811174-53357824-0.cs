    data = new GenerateNumberTransform(mlContext,  new GenerateNumberTransform.Arguments
                    {
                        Column = new[] { new GenerateNumberTransform.Column { Name = "random" } },
                        Seed = 42 // change seed to get a different split
                    }, data);
    (var train, var test) = mlContext.Regression.TrainTestSplit(data, stratificationColumn: "random");
