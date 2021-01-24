    <Page
        x:Class="App12.BlankPage2"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:App12"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    
        <Page.Resources>
            <local:VolumeConverter x:Key="cvt"/>
        </Page.Resources>
        <Grid>
            <StackPanel VerticalAlignment="Center" 
                        HorizontalAlignment="Center">
                <TextBox PlaceholderText="Input value in meter" 
                         Width="300" 
                         Text="{x:Bind InputValue, Mode=TwoWay}"/>
                <Button Content="Calculate" Click="Button_Click"/>
                <ComboBox x:Name="ComboBox_Amount_Unit" 
                          Margin="0,30,0,0" 
                          Loaded="ComboBox_Amount_Unit_Loaded">
                    <ComboBox.Items>
                        <ComboBoxItem Content="mm"/>
                        <ComboBoxItem Content="cm"/>
                        <ComboBoxItem Content="M"/>
                        <ComboBoxItem Content="kM"/>
                    </ComboBox.Items>
                </ComboBox>
                <TextBlock Name="outputTextBlock" 
                           FontSize="25" 
                           Text="{x:Bind Volume, Mode=OneWay, Converter={StaticResource cvt}}"/>
            </StackPanel>
        </Grid>
    </Page>
    
    
    
        public sealed partial class BlankPage2 : Page, INotifyPropertyChanged
            {
                public static BlankPage2 Current;
        
                public BlankPage2()
                {
                    this.InitializeComponent();
                    Current = this;
                }
        
               
        
                double _volume; 
        
                int _inputValue;
        
                public double Volume
                {
                    get { return _volume; }
                    set { _volume = value; RaisePropertyChanged(); }
                }
        
                public int InputValue
                {
                    get { return _inputValue; }
                    set { _inputValue = value; }
                }
        
                public int getIndex()
                {
                    return ComboBox_Amount_Unit.SelectedIndex;
                }
        
        
                public event PropertyChangedEventHandler PropertyChanged;
        
                void RaisePropertyChanged([CallerMemberName]string name = null)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(name));
                    }
                }
        
                private void ComboBox_Amount_Unit_SelectionChanged(object sender, SelectionChangedEventArgs e)
                {
                    if ((sender as ComboBox).SelectedIndex == 0)
                    {
                        Volume = InputValue * 1000000000;
                    }
                    else if ((sender as ComboBox).SelectedIndex == 1)
                    {
                        Volume = InputValue * 1000000;
                    }
                    else if ((sender as ComboBox).SelectedIndex == 2)
                    {
                        Volume = InputValue;
                    }
                    else if ((sender as ComboBox).SelectedIndex == 3)
                    {
                        Volume = InputValue / 1000000000;
                    }
                    else Volume = InputValue;
                }
        
                private void ComboBox_Amount_Unit_Loaded(object sender, RoutedEventArgs e)
                {
                    ComboBox_Amount_Unit.SelectedIndex = 0;
                    ComboBox_Amount_Unit.SelectionChanged += ComboBox_Amount_Unit_SelectionChanged;
                }
        
                private void Button_Click(object sender, RoutedEventArgs e)
                {
                    if (ComboBox_Amount_Unit.SelectedIndex == 0)
                    {
                        Volume = InputValue * 1000000000;
                    }
                    else if (ComboBox_Amount_Unit.SelectedIndex == 1)
                    {
                        Volume = InputValue * 1000000;
                    }
                    else if (ComboBox_Amount_Unit.SelectedIndex == 2)
                    {
                        Volume = InputValue;
                    }
                    else if (ComboBox_Amount_Unit.SelectedIndex == 3)
                    {
                        Volume = InputValue / 1000000000;
                    }
                    else Volume = InputValue;
                }
            }
    
    
        public class VolumeConverter: IValueConverter
            {
                public object Convert(object value, Type targetType, object parameter, string language)
                {
                    double val = (double)value;
        
                    if (val == 0.0) return "";
        
                    int index = BlankPage2.Current.getIndex();
        
                    if(index == 0)
                    {
                        return val.ToString() + " " + "mm";
                    }
                    else if(index == 1)
                    {
                        return val.ToString() + " " + "cm";
                    }
                    else if(index == 2)
                    {
                        return val.ToString() + " " + "m";
                    }
                    else if (index == 3)
                    {
                        return val.ToString() + " " + "km";
                    }
        
                    return val.ToString();
                }
        
                public object ConvertBack(object value, Type targetType, object parameter, string language)
                {
                    throw new NotImplementedException();
                }
            }
