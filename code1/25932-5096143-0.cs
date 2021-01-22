    protected void OnPropertyChanged<T>(Expression<Func<T>> property)
    {
        if (this.PropertyChanged != null)
        {
            var mex = property.Body as MemberExpression;
            string name = mex.Member.Name;
            this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
