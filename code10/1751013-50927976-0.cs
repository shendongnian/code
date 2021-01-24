    public class DummyController : ApiController
    {
       public SearchResultModel<DummyModel> Get([FromUri]SomeAdvanceFilterClass filter)
       {
         Logic logic = new Logic();
         return logic.GetResult(filters);
       }
    }
