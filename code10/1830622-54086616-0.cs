    public class ComputationService 
    {
        private IBaseRepository<User> _userRepo;
    
        public void Do(int id) 
        {
            using(AsyncScopedLifestyle.BeginScope(SimpleInjectorIntegrator.Container)) 
            {
                _userRepo = = SimpleInjectorIntegrator.Container.GetInstance<User>();
                var user = _userRepo.Get(id); //works fine.
            }
        }
    }
