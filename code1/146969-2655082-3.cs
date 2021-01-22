    public class UsageSample
    {
        public UsageSample()
        {
            //save a new object
            SampleObjectRepository repo = new SampleObjectRepository();
            SampleObject sampleObj = new SampleObject();
            repo.Save(sampleObj);
            
            //load an object by ID
            int id = sampleObj.ID;
            sampleObj = repo.Get(id);
            //delete an object
            repo.Delete(sampleObj);
        }
    }
