    interface IModel { }
    interface IService<out TModel>
    {
        TModel Create(IModel model);
    }
    interface IModelService<TModel, TService> where TModel : IModel where TService : IService<TModel>
    {
        TModel Model { get; set; }
        TService Service { get; set; }
    }
    class ExampleModel : IModel { }
    class ExampleService : IService<ExampleModel>
    {
        public ExampleModel Create(TModel model)
        {
            return new ExampleModel();
        }
    }
    class Example : ExampleBase<ExampleModel, ExampleService>
    {
    }
    abstract class ExampleBase<TModel, TService> : IModelService<TModel, TService> where TModel : IModel where TService : IService<TModel>
    {
        public TModel Model { get; set; }
        public TService Service { get; set; }
        protected bool Create()
        {
            //do what you must
        }
    }
