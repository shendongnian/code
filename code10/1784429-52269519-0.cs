        <DataGrid x:Name="DgLines" ItemsSource="{Binding OpcUaEndpoints}" AutoGenerateColumns="False"
                         SelectionMode="Extended"  IsReadOnly="True" Grid.ColumnSpan="5">
                            <DataGrid.Columns>
                                <DataGridTemplateColumn>
                                    <DataGridTemplateColumn.HeaderTemplate>
                                    <DataTemplate>
                                        <CheckBox Name="ckbSelectedAll" 
                                              IsChecked="{Binding IsSelected, UpdateSourceTrigger=PropertyChanged}">
                                                <i:Interaction.Triggers>
                                                    <i:EventTrigger EventName="Checked" >
                                                        <i:InvokeCommandAction Command="{Binding DataContext.CheckedCommand, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type DataGrid}}}" />
                                                    </i:EventTrigger>
                                                    <i:EventTrigger EventName="Unchecked" >
                                                        <i:InvokeCommandAction Command="{Binding DataContext.UncheckedCommand, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type DataGrid}}}" />
                                                    </i:EventTrigger>
                                                </i:Interaction.Triggers>
                                            </CheckBox>
                                    </DataTemplate>
                                    </DataGridTemplateColumn.HeaderTemplate>
                                    <DataGridTemplateColumn.CellTemplate>
                                        <DataTemplate>
                                            <CheckBox Name="cbkSelect" 
                                              IsChecked="{Binding IsSelected, UpdateSourceTrigger=PropertyChanged}"/>
                                        </DataTemplate>
                                    </DataGridTemplateColumn.CellTemplate>
                                </DataGridTemplateColumn>
                
                                <!--<DataGridTextColumn Width="200" Header="Id" Binding="{Binding Id }" />-->
                
                                <DataGridTextColumn Width="200" Header="Name" Binding="{Binding Name}"/>
                                <DataGridTextColumn Width="500" Header="Description" Binding="{Binding Description}"/>
                                <DataGridTextColumn Width="500" Header="Lines" Binding="{Binding Endpoint}"/>
                            </DataGrid.Columns>
                        </DataGrid>
            
            
            public class OpcUaEndpointsListViewModel : INotifyPropertyChanged
                {
                    private static OpcUaEndpointsListViewModel _instance;
                    private static readonly object Padlock = new object();
                    private ICommand _addCommand;
                    //private ICommand _uncheckCommand;
                    private ICommand _searchcommand;
                    private ICommand _checkedCommand { get; set; }
                    private ICommand _unCheckedCommand { get; set; }
            
                    private ObservableCollection<AddOpcUaEndpointsViewModel> _endpoint;
                    public string _charNameFromTB;
            
                    public event PropertyChangedEventHandler PropertyChanged;
            
                    public OpcUaEndpointsListViewModel()
                    {
                        BindDataGrid();
                    }
            
                    public static OpcUaEndpointsListViewModel Instance
                    {
                        get
                        {
                            lock (Padlock)
                            {
                                return _instance ?? (_instance = new OpcUaEndpointsListViewModel());
                            }
                        }
                    }
            
                    /// <summary>
                    ///     //OPC UA Endpoint List
                    /// </summary>
                    public ObservableCollection<AddOpcUaEndpointsViewModel> OpcUaEndpoints
                    {
                        get { return _endpoint; }
                        set
                        {
                            if (OpcUaEndpoints == value)
                            {
                                _endpoint = value;
                                OnPropertyChanged("OpcUaEndpoints");
                            }
                        }
                    }
            
                    public string CharNameFromTB
                    {
                        get { return _charNameFromTB; }
                        set
                        {
                            _charNameFromTB = value;
                            OnPropertyChanged("CharNameFromTB");
                        }
                    }
            
                    public ICommand AddCommand
                    {
                        get { return _addCommand ?? (_addCommand = new WpfApplication1.RelayCommand<object>(p => ExecuteAddCommand())); }
                    }
            
                    public ICommand SearchCommand
                    {
                        get { return _searchcommand ?? (_searchcommand = new RelayCommand<object>(p => ExecuteSearchCommand())); }
                    }
            
            
                    public ICommand CheckedCommand
                    {
                        get { return _checkedCommand ?? (_checkedCommand = new WpfApplication1.RelayCommand<object>(p => ExecuteCheckedCommand())); }
                    }
                    public ICommand UncheckedCommand
                    {
                        get { return _unCheckedCommand ?? (_unCheckedCommand = new WpfApplication1.RelayCommand<object>(p => ExecuteUnCheckedCommand())); }
                    }
            
            
                    private void ExecuteSearchCommand()
                    {
                        ///BindDataGridsearch();
                    }
            
                    private void ExecuteCheckedCommand()
                    {
                        foreach (var item in _endpoint)
                        {
                            item.IsSelected = true;
                        }
                    }
            
                    private void ExecuteUnCheckedCommand()
                    {
                        foreach (var item in _endpoint)
                        {
                            item.IsSelected = false;
                        }
                    }
            
                    private void ExecuteAddCommand()
                    {
                        ///BindDataGridsearch();
                    }
            
                    private void BindDataGrid()
                    {
                        _endpoint = new ObservableCollection<AddOpcUaEndpointsViewModel>();
                        _endpoint.Add(new AddOpcUaEndpointsViewModel { Name = "A", Description = "A", Endpoint = 1 });
                        _endpoint.Add(new AddOpcUaEndpointsViewModel { Name = "B", Description = "B", Endpoint = 2 });
                        _endpoint.Add(new AddOpcUaEndpointsViewModel { Name = "C", Description = "C", Endpoint = 3 });
                        _endpoint.Add(new AddOpcUaEndpointsViewModel { Name = "D", Description = "D", Endpoint = 4 });
                        _endpoint.Add(new AddOpcUaEndpointsViewModel { Name = "E", Description = "E", Endpoint = 5 });
                    }
            
                    public void OnPropertyChanged(string propertyName)
                    {
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                    }
                }
    
    public class AddOpcUaEndpointsViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            private string _name;
    
            public string Name
            {
                get { return _name; }
                set { _name = value; OnPropertyChanged("Name"); }
            }
    
            private string _description;
    
            public string Description
            {
                get { return _description; }
                set { _description = value; OnPropertyChanged("Description"); }
            }
    
            private int _endPoint;
    
            public int Endpoint
            {
                get { return _endPoint; }
                set { _endPoint = value; OnPropertyChanged("Endpoint"); }
            }
    
            private bool _isSelected;
    
            public bool IsSelected
            {
                get { return _isSelected; }
                set { _isSelected = value; OnPropertyChanged("IsSelected"); }
            }
        }
