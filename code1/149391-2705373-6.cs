    namespace Tvl.UI.ViewModel
    {
        using System.ComponentModel;
        public abstract class ViewModel<TModel> : INotifyPropertyChanged
        {
            protected ViewModel(TModel model)
            {
                this.Model = model;
            }
            public event PropertyChangedEventHandler PropertyChanged;
            public TModel Model
            {
                get;
                private set;
            }
            protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                var t = PropertyChanged;
                if (t != null)
                    t(this, e);
            }
        }
    }
