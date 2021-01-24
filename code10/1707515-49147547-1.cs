    [Authorize]
    public class TestModelsController : Controller
    {
        ...
        public TestModel Create(int id, string description)
        {
            var testModel = new TestModel { Id = id, Description = description };
            testModel.CreatedBy = this.User.Identity.Name;
            // store model (EntityFramework, etc...)
            // dbContext.TestModels.Add(testModel);
            // dbContext.SaveChanges();
            return testModel;
        }
        ...
    }
