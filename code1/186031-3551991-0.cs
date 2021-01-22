	public class Sample : TypeSafeNotifyPropertyChanged
	{
		private string _text;
	
		public string Text
		{
            get { return _text; }
            set
            {
                if (_text == value)
                    return;
                _text = value;
                OnPropertyChanged(() => Text);
            }
        }
	}
    public class TypeSafeNotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            PropertyChangedHelper.RaisePropertyChanged(this, propertyExpression, PropertyChanged);
        }
    }
	
	public static class PropertyChangedHelper
    {
        public static void RaisePropertyChanged<T>(object sender, Expression<Func<T>> propertyExpression, PropertyChangedEventHandler propertyChangedHandler)
        {
            if (propertyChangedHandler == null)
                return;
            if (propertyExpression.Body.NodeType != ExpressionType.MemberAccess)
                return;
            MemberExpression memberExpr = (MemberExpression)propertyExpression.Body;
            string propertyName = memberExpr.Member.Name;
            RaisePropertyChanged(sender, propertyName, propertyChangedHandler);
        }
        private static void RaisePropertyChanged(object sender, string property, PropertyChangedEventHandler propertyChangedHandler)
        {
            if (propertyChangedHandler != null)
                propertyChangedHandler(sender, new PropertyChangedEventArgs(property));
        }
    }
