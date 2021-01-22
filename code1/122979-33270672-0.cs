    <UserControl.Resources>
        <SolidColorBrush x:Key="{x:Static local:Foo.MyKey}">Blue</SolidColorBrush>
    </UserControl.Resources>
    <Grid Background="{StaticResource {x:Static local:Foo.MyKey}}" />
<!>
    public partial class Foo : UserControl
    {
        public Foo()
        {
            InitializeComponent();
            var brush = (SolidColorBrush)FindResource(MyKey);
        }
        public static ResourceKey MyKey { get; } = CreateResourceKey();
        private static ComponentResourceKey CreateResourceKey([CallerMemberName] string caller = null)
        {
            return new ComponentResourceKey(typeof(Foo), caller); ;
        }
    }
