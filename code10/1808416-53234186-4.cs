    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Loaded += WasLoaded;
        }
    
        private void WasLoaded(object sender, RoutedEventArgs e) {
    
            var children = VisualTreeHelper.GetChildrenRecursive(Button1);
            foreach (var child in children.OfType<Border>()) {
                if (child.Name == "Bord1") {
                    child.CornerRadius = new CornerRadius(1);
                    break;
                }
            }
    
        }
        
    }
    
    public static class VisualTreeHelper {
        /// <summary>
        /// Enumerates through element's children in the visual tree.
        /// </summary>
        public static IEnumerable<DependencyObject> GetChildrenRecursive(this DependencyObject element) {
            if (element == null) {
                throw new ArgumentNullException("element");
            }
    
            for (var i = 0; i < System.Windows.Media.VisualTreeHelper.GetChildrenCount(element); i++) {
                var child = System.Windows.Media.VisualTreeHelper.GetChild(element, i);
                yield return child;
    
                foreach (var item in child.GetChildrenRecursive()) {
                    yield return item;
                }
            }
        }
    
    }
