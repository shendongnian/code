    public interface ILegalViewModelBase 
    {
        void ReloadCollection();
    }
    public interface ILegalViewModelBase<T> : ILegalViewModelBase
    {
        ObservableCollection<T> MasterCollection { get; set; }
    }
    public abstract class LegalViewModelBase<T> : BindableBase, ILegalViewModelBase<T>
    {
        public ObservableCollection<T> MasterCollection
        {
            get => _masterCollection;
            set => SetProperty(ref _masterCollection, value, ReloadCollection);
        }
        private ObservableCollection<T> _masterCollection;
    }
