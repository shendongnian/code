    public abstract class CpFileMgrController<TModel>:Controller 
        where TModel: class, new()
    {
        private TModel _model = new TModel();
        public TModel Model{ get{ return _model; } }
        public CpFileMgrController() {
            ViewData.Model = _model;
        }
    }
