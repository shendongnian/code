    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        AnyClass c = new AnyClass();
        private void h1_Click(object sender, RoutedEventArgs e)
        {
            Test = true;
        }
        private void h2_Click(object sender, RoutedEventArgs e)
        {
            Test = false;
        }
        
        public bool Test
        {
            get { return (bool)GetValue(TestProperty); }
            set
            {
                SetValue(TestProperty, value);
                c.Val = value;
            }
        }
        public static readonly DependencyProperty TestProperty =
            DependencyProperty.Register("Test", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));
    }
    [AnyClass.cs]
    class AnyClass
    {
        private bool val = false;
        public bool Val
        {
            get
            {
                return val;
            }
            set
            {
                val = value;
            }
        }
    }
    
    [mainWindow.xaml]
    <Button Click="h1_Click" Content="true">
                <Button.Style>
                    <Style TargetType="Button">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding ElementName=hUserControl, Path=Test}" Value="True">
                                <Setter Property="Visibility" Value="Collapsed"/>
                            </DataTrigger>
                            <DataTrigger Binding="{Binding ElementName=hUserControl, Path=Test}" Value="False">
                                <Setter Property="Visibility" Value="Visible"/>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </Button.Style>
            </Button>
            <Button Click="h2_Click" Content="false">
                <Button.Style>
                    <Style TargetType="Button">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding ElementName=hUserControl, Path=Test}" Value="True">
                                <Setter Property="Visibility" Value="Visible"/>
                            </DataTrigger>
                            <DataTrigger Binding="{Binding ElementName=hUserControl, Path=Test}" Value="False">
                                <Setter Property="Visibility" Value="Collapsed"/>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </Button.Style>
            </Button>
