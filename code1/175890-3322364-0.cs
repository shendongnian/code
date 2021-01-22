    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
            }
        }
    
        public class NavigableViewport3D : Viewport3D
        {
            public static readonly new DependencyProperty CameraProperty;
    
            static NavigableViewport3D()
            {
                NavigableViewport3D.CameraProperty = Viewport3D.CameraProperty.AddOwner( typeof( NavigableViewport3D ) );
            }
        }
    }
