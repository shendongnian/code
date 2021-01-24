    namespace WpfApplication
    {
    	public partial class BindingTest
    	{
    		public static readonly DependencyProperty TestProperty =
    			DependencyProperty.Register(
    				"Test", typeof(string),
    				typeof(BindingTest)
    			);
    
    		public string Test
    		{
    			get => (string)GetValue(TestProperty);
    			set => SetValue(TestProperty, value);
    		}
    
    		public BindingTest()
    		{
    			InitializeComponent();
    		}
    	}
    }
    <UserControl x:Class="WpfApplication.BindingTest"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
                 xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
                 xmlns:local="clr-namespace:WpfApplication"
                 mc:Ignorable="d" 
                 d:DesignHeight="450" d:DesignWidth="800">
        <TextBlock Text="{Binding Test, RelativeSource={RelativeSource AncestorType=local:BindingTest}}" />
    </UserControl>
