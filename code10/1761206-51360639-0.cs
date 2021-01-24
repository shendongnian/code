    [TestFixture]
    public class AnotherFixture
    {
      [Test, Apartment(ApartmentState.MTA)]
      public void TestRequiringMTA()
      {
        // This test will run in the MTA.
      }
  
      [Test, Apartment(ApartmentState.STA)]
      public void TestRequiringSTA()
      {
        // This test will run in the STA.
      }
    }
