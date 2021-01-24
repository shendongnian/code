using System.Windows;
using System.Windows.Controls;
namespace Custom_Control_Elipse_2_labels
{
    /// <summary>
    /// Interaction logic for EllipseWithTwoLabels.xaml
    /// </summary>
    public partial class EllipseWithTwoLabels : UserControl
    {
        public static readonly DependencyProperty Content1Property = DependencyProperty.Register("Content1", typeof(string), typeof(EllipseWithTwoLabels));
        public static readonly DependencyProperty Content2Property = DependencyProperty.Register("Content2", typeof(string), typeof(EllipseWithTwoLabels));
        public EllipseWithTwoLabels()
        {
            InitializeComponent();
            DataContext = this;
        }
        public string Content1
        {
            get => (string) GetValue(Content1Property);
            set => SetValue(Content1Property,value);
        }
        public string Content2
        {
            get => (string)GetValue(Content2Property);
            set => SetValue(Content2Property, value);
        }
    }
}
The .xaml for the user control being
<Grid>
        <Label Content="{Binding Content1}" Style="{StaticResource RoundedButtonStyle}" HorizontalAlignment="Center" VerticalAlignment="Center"  Background="Red" BorderBrush="Red" BorderThickness="3" Height="100" Width="100" FontSize="20" FontWeight="Bold" ></Label>
        <Label Content="{Binding Content2}" Margin="0,150,0,0"  HorizontalAlignment="Center" VerticalAlignment="Center" ></Label>
    </Grid>
You can then just import it into any view to use it with: (
xmlns:local="clr-namespace:Custom_Control_Elipse_2_labels" 
And use with the xaml:
 <local:EllipseWithTwoLabels Height="300" Width="300" Content1="Content #1" Content2="Content #2"/>
Is one way to get it done :) 
It provides something like this:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/agIPG.png
