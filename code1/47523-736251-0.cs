    public class State : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanging(PropertyChangingEventArgs e)
        {
            if (this.PropertyChanging != null)
            {
                this.PropertyChanging(this, e);
            }
        }
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, e);
            }
        }
        public bool Foo
        {
            get
            {
                return foo;
            }
            set
            {
                if (value != foo)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("Foo"));
                    foo = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("Foo"));
                }
            }
        }
        private bool foo = false;
    }
    protected void HandleStateChanged(object sender, PropertyChangedEventArgs e)
    {
        if(e.PropertyName == "Foo")
        {
            box.Text = state.Foo ? "Enabled" : "Disabled";
        }
    }
