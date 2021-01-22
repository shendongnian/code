    /// <summary>
    /// Interaction logic for InPageDialog.xaml
    /// </summary>
    public partial class InPageDialog : UserControl, INotifyPropertyChanged 
    {
        public InPageDialog()
        {
            InitializeComponent();
        }
        public void Show(IDialog ucContent)
        {                        
        }
        void ucContent_OnClose(object obj)
        {
            
        }
        protected virtual void Changed(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public static readonly DependencyProperty ContentBackgroundProperty = DependencyProperty.Register("ContentBackground", typeof(Brush), typeof(InPageDialog), new UIPropertyMetadata(Brushes.White));
        public Brush ContentBackground 
        {
            get { return (Brush)GetValue(ContentBackgroundProperty); }
            set { SetValue(ContentBackgroundProperty, value); }
        }
        public static readonly DependencyProperty ContentBorderBrushProperty = DependencyProperty.Register("ContentBorderBrush", typeof(Brush), typeof(InPageDialog), new UIPropertyMetadata(Brushes.White));
        public Brush ContentBorderBrush 
        {
            get { return (Brush)GetValue(ContentBorderBrushProperty); }
            set { SetValue(ContentBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty ContentActiveBackgroundProperty = DependencyProperty.Register("ContentActiveBackground", typeof(Brush), typeof(InPageDialog), new UIPropertyMetadata(Brushes.White));
        public Brush ContentActiveBackground 
        {
            get { return (Brush)GetValue(ContentActiveBackgroundProperty); }
            set { SetValue(ContentActiveBackgroundProperty, value); }
        }
        public static readonly DependencyProperty ContentBorderThicknessProperty = DependencyProperty.Register("ContentBorderThickness", typeof(Thickness), typeof(InPageDialog));
        public Thickness ContentBorderThickness 
        {
            get { return (Thickness)GetValue(ContentBorderThicknessProperty); }
            set { SetValue(ContentBorderThicknessProperty, value); }
        }
        public static readonly DependencyProperty ContentBlurRadiusProperty = DependencyProperty.Register("ContentBlurRadius", typeof(double), typeof(InPageDialog));
        public double ContentBlurRadius 
        {
            get { return (double)GetValue(ContentBlurRadiusProperty); }
            set { SetValue(ContentBlurRadiusProperty, value); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public interface IDialog
    {
        event Action<object> OnClose;
    }
}
    <UserControl x:Class="xxx.Wpf.InPageDialog"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:me="clr-namespace:xxx.Wpf"
    Visibility="Collapsed" DataContext="{Binding}">
    <UserControl.Resources>
        <Style TargetType="{x:Type Button}">
            <Setter Property="Margin" Value="4"/>
            <Setter Property="Width" Value="60"/>
        </Style>
    </UserControl.Resources>
    <UserControl.Template>
        <ControlTemplate TargetType="{x:Type me:InPageDialog}">
        <Grid HorizontalAlignment="Stretch"  VerticalAlignment="Stretch" DataContext="{TemplateBinding DataContext}">
            <Rectangle HorizontalAlignment="Stretch" 
                       VerticalAlignment="Stretch" 
                       Opacity="0.765" 
                       Fill="{TemplateBinding ContentBackground}" />
            <Border VerticalAlignment="Center" 
                    HorizontalAlignment="Center" 
                    CornerRadius="5" 
                    BorderBrush="{TemplateBinding ContentBorderBrush}" 
                    BorderThickness="{TemplateBinding ContentBorderThickness}" 
                    Background="{TemplateBinding ContentActiveBackground}" >
                <ContentPresenter Margin="0" Width="Auto" Height="Auto" Content="{TemplateBinding Content}" />
            </Border>
        </Grid>
        </ControlTemplate>
    </UserControl.Template>
