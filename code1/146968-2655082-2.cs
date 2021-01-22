    public class SampleObjectRepository : CacheRepository<SampleObject>
    {
        protected override SampleObject  GetData(int id)
        {
            //do some loading
            return new SampleObject();
        }
        protected override void  SaveData(SampleObject obj)
        {
            //do some saving
        }
        protected override void  DeleteData(SampleObject obj)
        {
            //do some deleting
        }
    }
