    <Window x:Class="Test.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:Test"
            mc:Ignorable="d"
            xmlns:viewmodel="clr-namespace:Test.ViewModel"
            xmlns:commands="clr-namespace:Test.ViewModel.Commands"
            Title="MainWindow" Height="350" Width="525">
        <Window.Resources>
            <viewmodel:ViewModelBase  x:Key="base" ></viewmodel:ViewModelBase>
            <viewmodel:Converters  x:Key="convert" ></viewmodel:Converters>
        </Window.Resources>
        <StackPanel>
            <Button Width="100" Height="30" Command="{Binding Source={StaticResource base},Path=YesCommand}"/>
            <TextBox DataContext="{StaticResource base}" Text="{Binding Source={StaticResource base},Path=Sname , Mode=TwoWay}"/>
            <CheckBox DataContext="{StaticResource base}" IsChecked="{Binding Sname , Mode=TwoWay , Converter={StaticResource convert}}"  />
            <TextBox />
        </StackPanel>
    </Window>
    public class ViewModelBase : INotifyPropertyChanged
        {
            private string _s;
    
            private Commands.SetYesCommand _yesCommand;
    
            public ViewModelBase()
            {
                _yesCommand = new SetYesCommand(this);
            }
    
            public string Sname
            {
                get { return _s; }
                set
                {
                    _s = value;
                    onPropertyChanged("Sname");
                }
    
            }
    
            public SetYesCommand YesCommand => _yesCommand;
    
            private void onPropertyChanged(string propertyname)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    public class SetYesCommand : ICommand, INotifyPropertyChanged
    {
        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        private ViewModelBase view;
        public SetYesCommand(ViewModelBase view)
        {
            this.view = view;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            view.Sname = "Yes";
            MessageBox.Show("Command works");
            onpropertychanged("Sname");
        }
        private void onpropertychanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
