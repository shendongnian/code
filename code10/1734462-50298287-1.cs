    public class SampleService
    {
         IEnumerable<SampleModel> RetrieveSamples()
         {
              using(var context = new SampleFactory().Create())
                   return context.GetAllSamples();
         }
    }
