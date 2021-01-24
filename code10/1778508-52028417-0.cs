    public abstract class BaseModel<TModel>
    {
        public string Name { get; set; }
    }
    public abstract class BaseViewModel<TModel> where TModel : BaseModel<TModel>
    {
        protected readonly TModel baseModel;
        public BaseViewModel(TModel baseModel)
        {
            this.baseModel = baseModel;
        }
        public string Name
        {
            get => baseModel.Name;
            set => baseModel.Name = value;
        }
    }
    public class UseableModel : BaseModel<UseableModel>
    {
        public string NewVar { get; set; }
    }
    public class UseableViewModel : BaseViewModel<UseableModel>
    {
        public UseableViewModel(UseableModel model) : base(model) { }
        public string NewVar
        {
            get => baseModel.NewVar;
            set => baseModel.NewVar = value;
        }
    }
