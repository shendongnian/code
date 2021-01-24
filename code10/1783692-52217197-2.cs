    //C# Code
    //Define a ViewModel
    public class VM : INotifyPropertyChanged
    {
        private DataSet _ds;
        public event PropertyChangedEventHandler PropertyChanged;
        public DataSet Ds
        {
            get => _ds;
            set
            {
                _ds = value;
                //Notify: Property "Ds" updated
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ds"));
            }
        }
    }
    public MainWindow()
    {
        DataContext = new VM();
        //set viewmodel to DataContext before InitializeComponent
        InitializeComponent();
        loadUserCB();
    }
---
    <!--Xaml Code-->
    <!--                            V Note here.*-->
    <ComboBox ItemsSource="{Binding Tables[TUserDS]}" 
              x:Name="UserCB" 
              SelectionChanged="UserCB_SelectionChanged" 
              Width="200" 
              HorizontalAlignment="left"
              SelectedIndex="0" 
              Padding="2"
              Margin="0 10 0 0">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <StackPanel>
                    <TextBlock Text="{Binding UserName}"/>
                </StackPanel>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
