    public class BindableStringBuilder : INotifyPropertyChanged
    {
        private readonly StringBuilder _builder = new StringBuilder();
        private EventHandler<EventArgs> TextChanged;
        public void Append(string text)
        {
            _builder.Append(text);
            if (TextChanged != null)
                TextChanged(this, null);
            RaisePropertyChanged(() => Text);
        }
        public void AppendLine(string text)
        {
            _builder.AppendLine(text);
            if (TextChanged != null)
                TextChanged(this, null);
            RaisePropertyChanged(() => Text);
        }
        public string Text
        {
            get { return _builder.ToString(); }
        }
        public int Count
        {
            get { return _builder.Length; }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                return;
            }
            var handler = PropertyChanged;
            if (handler != null)
            {
                var body = propertyExpression.Body as MemberExpression;
                if (body != null)
                    handler(this, new PropertyChangedEventArgs(body.Member.Name));
            }
        }
        #endregion
    }
