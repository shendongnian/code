    <UserControl x:Class="ColorPickerTest.ColorPicker"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
        
        <StackPanel Orientation="Horizontal">
            <ToggleButton Name="redButton" Content="Red" Click="Button_Click" />
            <ToggleButton Name="yellowButton" Content="Yellow" Click="Button_Click" />
        </StackPanel>
    </UserControl>
    
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    namespace ColorPickerTest
    {
        public partial class ColorPicker : UserControl
        {
            public ColorPicker()
            {
                InitializeComponent();
            }
    
            public Brush SelectedColor
            {
                get { return (Brush)GetValue(SelectedColorProperty); }
                set { SetValue(SelectedColorProperty, value); }
            }
    
            public static readonly DependencyProperty SelectedColorProperty =
                DependencyProperty.Register("SelectedColor", 
                                            typeof(Brush), 
                                            typeof(ColorPicker), 
                                            new UIPropertyMetadata(Brushes.Transparent, OnPropertyChanged));
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (!redButton.IsChecked.GetValueOrDefault() && !yellowButton.IsChecked.GetValueOrDefault())
                {
                    SelectedColor = Brushes.Transparent;
                }
                else if (!redButton.IsChecked.GetValueOrDefault() && yellowButton.IsChecked.GetValueOrDefault())
                {
                    SelectedColor = Brushes.Yellow;
                }
                else if (redButton.IsChecked.GetValueOrDefault() && !yellowButton.IsChecked.GetValueOrDefault())
                {
                    SelectedColor = Brushes.Red;
                }
                else
                {
                    // redButton.IsChecked.GetValueOrDefault() && yellowButton.IsChecked.GetValueOrDefault())
    
                    SelectedColor = Brushes.Orange;
                }
            }
            private static void OnPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                ColorPicker colorPicker = sender as ColorPicker;
                colorPicker.redButton.IsChecked = colorPicker.SelectedColor == Brushes.Red ||
                                                  colorPicker.SelectedColor == Brushes.Orange;
                colorPicker.yellowButton.IsChecked = colorPicker.SelectedColor == Brushes.Yellow ||
                                                     colorPicker.SelectedColor == Brushes.Orange;
            }
        }
    }
    
    <Window x:Class="ColorPickerTest.Window1"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:ColorPickerTest="clr-namespace:ColorPickerTest"
        Height="300" Width="300">
        <StackPanel>
            <ColorPickerTest:ColorPicker SelectedColor="{Binding Path=MyColor, Mode=TwoWay}" />
        </StackPanel>
    </Window>
    
    using System.Windows;
    using System.Windows.Media;
    
    namespace ColorPickerTest
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
    
                MyColor = Brushes.Red;
    
                DataContext = this;
            }
    
            private Brush _myColor;
            public Brush MyColor
            {
                get { return _myColor; }
                set 
                {
                    _myColor = value;
                    Background = _myColor;
                }
            }
        }
    }
