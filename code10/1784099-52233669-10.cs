    byte[] byteArray = new byte[123456];
    foreach (var batch in AsBatches(byteArray, 640))
    {
        Console.WriteLine(batch.Length); // Do something with the batch.
    }
