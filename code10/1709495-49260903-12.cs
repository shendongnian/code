    public class MainVM
    {
        public ObservableCollection<Thingy> Thingies { get; set; }
        public ICommand FooCommand { get; set; }
        public MainVM()
        {
            Thingies = new ObservableCollection<Thingy>();
            FooCommand = new Command(Bar);
        }
        private void Bar(object eventArgs)
        {
            var args = eventArgs as SelectedItemChangedEventArgs;
            if (args == null)
                return;
            var selectedItem = args.SelectedItem;
        }
    }
