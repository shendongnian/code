    public abstract class Base<TModel> 
    {
        public TModel Model { get; set; }
        protected abstract IService GetService();
        protected bool Create()
        {
            IService service = GetService();
            try
            {
                Model = service.Create(Model);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
