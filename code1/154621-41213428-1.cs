    public class HideableControl<T>: Control where T: class
    {
        private string _propertyName;
        private PropertyInfo _propertyInfo;
    
        public string PropertyName
        {
            get { return _propertyName; }
            set
            {
                _propertyName = value;
                _propertyInfo = typeof(T).GetProperty(value);
            }
        }
    
        protected override bool GetIsVisible(IRenderContext context)
        {
            if (_propertyInfo == null)
                return false;
    
            var model = context.Get<T>();
    
            if (model == null)
                return false;
    
            return (bool)_propertyInfo.GetValue(model, null);
        }
    
        protected void SetIsVisibleProperty(Expression<Func<T, bool>> propertyLambda)
        {
            var expression = propertyLambda.Body as MemberExpression;
            if (expression == null)
                throw new ArgumentException("You must pass a lambda of the form: 'vm => vm.Property'");
    
            PropertyName = expression.Member.Name;
        }
    }
    
    public interface ICompanyViewModel
    {
        string CompanyName { get; }
        bool IsVisible { get; }
    }
    
    public class CompanyControl: HideableControl<ICompanyViewModel>
    {
        public CompanyControl()
        {
            SetIsVisibleProperty(vm => vm.IsVisible);
        }
    }
