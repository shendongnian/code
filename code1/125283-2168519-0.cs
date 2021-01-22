    public class ClosedSourceObjectViewModel : ViewModelBase
    {
        private ClosedSourceObject ClosedSourceObject
        {
            get;
            set;
        }
        public bool SomeProperty
        {
            get { return this.ClosedSourceObject.SomeProperty; }
            set
            {
                if (value != this.ClosedSourceObject.SomeProperty)
                {
                    RaisePropertyChanging("SomeProperty");
                    this.ClosedSourceObject.SomeProperty = value;
                    RaisePropertyChanged("SomeProperty");
                }
            }
        }
    }
