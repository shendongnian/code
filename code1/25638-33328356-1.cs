    [Test]
    public void Randomness_SecureDoubleTest()
    {
      RunTrials(1000, 0.02);
      RunTrials(10000, 0.01);
    }
    private static void RunTrials(int sampleSize, double errorMargin)
    {
      var q = new Queue<double>();
      while (q.Count < sampleSize)
      {
        q.Enqueue(Randomness.NextSecureDouble());
      }
      for (int k = 0; k < 1000; k++)
      {
        // rotate
        q.Dequeue();
        q.Enqueue(Randomness.NextSecureDouble());
        var avg = q.Average();
        // Dividing by n−1 gives a better estimate of the population standard
        // deviation for the larger parent population than dividing by n, 
        // which gives a result which is correct for the sample only.
        var actual = Math.Sqrt(q.Sum(x => (x - avg) * (x - avg)) / (q.Count - 1));
        // see http://stats.stackexchange.com/a/1014/4576
        var expected = (q.Max() - q.Min()) / Math.Sqrt(12);
        Assert.AreEqual(expected, actual, errorMargin);
      }
    }
