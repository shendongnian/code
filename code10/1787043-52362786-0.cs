    <Window
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:WpfApplication1"
            xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
            xmlns:Themes="clr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero" x:Class="WpfApplication1.MainWindow"
            mc:Ignorable="d"
            Title="MainWindow" Height="450" Width="800">
    
        <Window.Resources>       
            <Style TargetType="{x:Type ComboBoxItem}">
                <Setter Property="SnapsToDevicePixels" Value="true" />
                <Setter Property="OverridesDefaultStyle" Value="true" />
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type ComboBoxItem}">
                            <Border x:Name="Border" Padding="2" SnapsToDevicePixels="true" Background="Transparent">                            
                                <ContentPresenter />
                            </Border>
                            <ControlTemplate.Triggers>
                                <Trigger Property="Content" Value="Weekly">
                                    <Setter Property="TextBlock.Foreground" TargetName="Border" Value="Green"/>
                                </Trigger>
                                <Trigger Property="Content" Value="BiWeekly">
                                    <Setter Property="TextBlock.Foreground" TargetName="Border" Value="Blue"/>
                                </Trigger>
                                <Trigger Property="Content" Value="Monthly">
                                    <Setter Property="TextBlock.Foreground" TargetName="Border" Value="Orange"/>
                                </Trigger>
                                <Trigger Property="Content" Value="SemiMonthly">
                                    <Setter Property="TextBlock.Foreground" TargetName="Border" Value="Red"/>
                                </Trigger>
                                <Trigger Property="Content" Value="Quarterly">
                                    <Setter Property="TextBlock.Foreground" TargetName="Border" Value="YellowGreen"/>
                                </Trigger>
                                <Trigger Property="Content" Value="SemiAnnually">
                                    <Setter Property="TextBlock.Foreground" TargetName="Border" Value="Purple"/>
                                </Trigger>
                                <Trigger Property="Content" Value="Annually">
                                    <Setter Property="TextBlock.Foreground" TargetName="Border" Value="HotPink"/>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Window.Resources>
    
        <Window.DataContext>
            <local:MainViewModel/>
        </Window.DataContext>
    
        <Grid Background="{Binding BackgroundColor}" HorizontalAlignment="Stretch" VerticalAlignment="Stretch">       
            <ComboBox x:Name="cboPayFrequency" Grid.Column="4" Grid.Row="7" VerticalAlignment="Center" ItemsSource="{Binding PayFrequencies}" SelectedValue="{Binding SelectedFrequency}">
            </ComboBox>
        </Grid>
    </Window>
    
    
    public class MainViewModel : INotifyPropertyChanged
        {
            private List<string> _payFrequencies;
    
            public List<string> PayFrequencies
            {
                get { return _payFrequencies; }
                set { _payFrequencies = value; NotifyPropertyChanged("PayFrequencies"); }
            }
    
            private string _selectedFrequency;
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public string SelectedFrequency
            {
                get { return _selectedFrequency; }
                set { _selectedFrequency = value; NotifyPropertyChanged("SelectedFrequency"); }
            }
    
            public MainViewModel()
            {
                Initialize();
            }
    
            public void NotifyPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            private void Initialize()
            {
                PayFrequencies = new List<string>();
                PayFrequencies.Add("Weekly");
                PayFrequencies.Add("BiWeekly");
                PayFrequencies.Add("Monthly");
                PayFrequencies.Add("SemiMonthly");
                PayFrequencies.Add("Quarterly");
                PayFrequencies.Add("SemiAnnually");
                PayFrequencies.Add("Annually");
    
                SelectedFrequency = "Annually";
            }
        }
