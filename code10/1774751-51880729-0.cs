    public class FakeTestService : Service
    {
        ....
        protected override bool SaveToDB()
        {
            // do nothing
            return true;
        }
    }
