    [TestFixture]
    public class SpotTest
    {
      [VerifyContract]
      public readonly IContract HashCodeAcceptanceTests = new HashCodeAcceptanceContract<Spot>()
      {
        CollisionProbabilityLimit = CollisionProbability.VeryLow,
        UniformDistributionQuality = UniformDistributionQuality.Excellent,
        DistinctInstances = DataGenerators.Join(Enumerable.Range(0, 1000), Enumerable.Range(0, 1000)).Select(o => new Spot(o.First, o.Second))
      };
    }
