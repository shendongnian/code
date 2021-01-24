    public class MyVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand OpenWindow1Command { get; }
        public ICommand OpenWindow2Command { get; }
        public MyVm()
        {
            OpenWindow1Command = new RelayCommand(OpenWindow1Command_Execute);
            OpenWindow2Command = new RelayCommand(OpenWindow2Command_Execute);
        }
        void OpenWindow1Command_Execute(object parameter)
        {
            var point = (Point)parameter;
            var win1 = new Window1{WindowStartupLocation = WindowStartupLocation.Manual, Left = point.X, Top = point.Y};
            win1.Show();
        }
        void OpenWindow2Command_Execute(object parameter)
        {
            var point = (Point)parameter;
            var win2 = new Window2 { WindowStartupLocation = WindowStartupLocation.Manual, Left = point.X, Top = point.Y };
            win2.Show();
        }
    } 
