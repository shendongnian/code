    public class TestController
    {
        private IUnitOfWork unitOfWork;
    
        public TestController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
