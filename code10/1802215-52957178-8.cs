    public interface IModel
    {
        bool Initialized { get; }
    }
    public interface IPlugin<TModel> where TModel: struct, IModel
    {
        event ChangesAppliedDelegate<TModel> ChangesApplied;
        TModel Model { get; }
        void SetData(TModel model);
    }
    public delegate void ChangesAppliedDelegate<in TModel>(TModel model) where TModel : struct, IModel;
