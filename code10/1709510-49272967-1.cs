    public partial class MainWindow : Window
    {
        int count = 0;
        private Projector _Projector;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += _OnLoaded;
        }
        private void _OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            unsafe
            {
                var qtApp = new QApplication(ref count, null);
            }
            _Projector = new Projector();
            
        }
        private void ButtonBase_OnClickOpen(object sender, RoutedEventArgs e)
        {
            _Projector.Show();
        }
        
        private void ButtonBase_OnClickPaint(object sender, RoutedEventArgs e)
        {
            _Projector.X += 10;
            _Projector.Y += 5;
            if(_Projector.Info.Hidden)
                _Projector.Info.Show();
            else
            {
                _Projector.Info.Hide();                
            }
            _Projector.Paint();
        }
    }
    public class Projector : QWidget
    {
        public int X { get; set; } = 123;
        public int Y { get; set; } = 12;
        public QQuickWidget Info;
        public QObject qmlRoot;
        public Projector()
        {
            WindowTitle = "Paint Demo";
            Palette.SetColor(QPalette.ColorRole.Background, QColor.FromRgb(0,0,0));
 
            Resize(800, 800);
            Show();
            Info = new QQuickWidget(this);
            Info.Source = new QUrl(@"\QML\main.qml");
            Info.RootObject.SetProperty("componentName", "lorem ipsum");
            Info.resizeMode = QQuickWidget.ResizeMode.SizeRootObjectToView;
            Info.Geometry = new QRect(50, 10, 100, 300);
            Info.Show();
        }
        
        protected override void OnPaintEvent(QPaintEvent e)
        {
            base.OnPaintEvent(e);
            var painter = new QPainter(this);
            painter.SetRenderHint ( QPainter.RenderHint.Antialiasing );
            DrawPatternsEx ( painter );
            painter.End();
        }
        void DrawPatternsEx(QPainter ptr)
        {
            ptr.SetPen(PenStyle.SolidLine);
            ptr.SetPen(QColor.FromRgb(255,0,0));
            ptr.DrawLine(0, Y, Size.Width, Y);
            ptr.DrawLine(X, 0, X, Size.Height);
        }
        public void Paint()
        {
            Update();
        }
    }
