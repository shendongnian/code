    public abstract class Base<TModel, TService> where TService: IService
    {
        public TModel Model { get; set; }
        private TService Service { get; set; }
        protected bool Create()
        {
            try
            {
                Model = Service.Create(Model);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
