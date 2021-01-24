       public class ViewModel
        {
            private ObservableCollection<SetupSF> _sourceForSFList = new ObservableCollection<SetupSF>();
    
            public ViewModel()
            {
                _sourceForSFList = new ObservableCollection<SetupSF>()
                {
                    new SetupSF() { SFName = "One", OwnedSFEs = new ObservableCollection<SetupSFE> () { new SetupSFE() { SFEName = "Three" }, new SetupSFE() { SFEName = "Four" } } },
                    new SetupSF() { SFName = "Two", OwnedSFEs = new ObservableCollection<SetupSFE> () { new SetupSFE() { SFEName = "Five" }, new SetupSFE() { SFEName = "Six" } } }
                };
                _sourceForSFEList = new ObservableCollection<SetupSFE>()
                {
                    new SetupSFE() { SFEName = "One"},
                    new SetupSFE() { SFEName = "Two"}
                };
            }
    
            private SetupSF _selectedSF;
            public SetupSF SelectedSF
            {
                get { return _selectedSF; }
                set
                {
                    _selectedSF = value;
                    if (_selectedSF != null)
                    {
                        SourceForSFEList = _selectedSF.OwnedSFEs;
                    }
                }
            }
    
            public ObservableCollection<SetupSF> SourceForSFList
            {
                get { return _sourceForSFList; }
                set
                {
                    _sourceForSFList = value;
                }
            }
    
            private ObservableCollection<SetupSFE> _sourceForSFEList = new ObservableCollection<SetupSFE>();
            public ObservableCollection<SetupSFE> SourceForSFEList
            {
                get { return _sourceForSFEList; }
                set
                {
                    _sourceForSFEList.Clear();
                    if (value != null)
                    {
                        foreach (var item in value)
                        {
                            _sourceForSFEList.Add(item);
                        }
                        
                    }
                }
            }
    
        }
    
        public class SetupSF
        {
            public String SFName { get; set; }
            public ObservableCollection<SetupSFE> OwnedSFEs;
        }
    
        public class SetupSFE
        {
            public String SFEName { get; set; }
        }
    <Page
        x:Class="App7.MainPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:App7"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    
        <Page.DataContext>
            <local:ViewModel />
        </Page.DataContext>
        
        <StackPanel Orientation="Horizontal">
            <ComboBox x:Name="ComboBoxA" 
              Width="350" 
              ItemsSource="{Binding SourceForSFList}"
              SelectedItem="{Binding SelectedSF, Mode=TwoWay}"
              DisplayMemberPath="SFName" Margin="10"/>
    
            <ComboBox x:Name="ComoboxB"
              Width="350"
              ItemsSource="{Binding SourceForSFEList}"
              SelectedItem="{Binding SelectedSFE, Mode=TwoWay}"   
              DisplayMemberPath="SFEName" Margin="10"/>
        </StackPanel>
    </Page>
