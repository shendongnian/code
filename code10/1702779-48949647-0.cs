    public class MainViewModel : BindableBase
    {
        readonly ListViewModel listViewModel = new ListViewModel();
        public int NumberOfWorkOrders => listViewModel.WorkOrders.Count();
        public MainViewModel()
        {
            // since you already rise notification in ListViewModel
            // listen to it and "propagate"
            listViewModel.PropertyChanged += (s, e) =>
            {
                if(e.PropertyName == nameof(ListViewModel.NumberOfWorkOrders))
                    OnPropertyChanged(nameof(NumberOfWorkOrders));
            };
        }
    }
