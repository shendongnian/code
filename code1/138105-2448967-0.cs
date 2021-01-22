    public abstract class BaseBusinessAction<TActionParameters> 
        : where TActionParameters : IActionParameters
    {
        protected abstract TActionParameters Parameters { get; }
        protected abstract bool ParametersAreValid();
        public void CommonMethod() { ... }
    }
