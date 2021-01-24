    public class MainViewModel : ViewModelBase
    {
        private readonly Model Data;
        public MainViewModel()
        {
            Data = new Model();
            Data.PropertyChanged += ModelOnPropertyChanged;
        }
        private void ModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Model.BoundTextProperty):
                    OnPropertyChanged(nameof(MainViewModel.BoundTextProperty));
                    break;
                // add cases for other properties here:
            }
        }
        public string BoundTextProperty => Data.BoundTextProperty;
    }
    public class Model : ModelBase
    {
        private long number;
        public long Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged(nameof(BoundTextProperty));
            }
        }
        public string BoundTextProperty => $"Some text {Number} some text again";
    }
    public abstract class ViewModelBase : Base
    {
        // add other ViewModel related stuff here
    }
    public abstract class ModelBase : Base
    {
        // add other Model related stuff here
    }
    public abstract class Base : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
