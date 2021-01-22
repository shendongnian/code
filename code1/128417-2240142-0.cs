    public class MyViewModel : INotifyPropertyChanged
    {
        private readonly ICommand mutateCommand;
        private Thing thing;
        public MyViewModel()
        {
            this.mutateCommand = new RelayCommand(this.Mutate);
        }
        public ICommand MutateCommand
        {
            get { return this.mutateCommand; }
        }
        public Thing Thing
        {
            get { return this.thing; }
            set
            {
                this.thing = value;
                // raise PropertyChanged event here...
            }
        }
        private void Mutate(object parameter)
        {
            this.Thing = new Thing();
        }
    }
