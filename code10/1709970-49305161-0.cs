    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    
    namespace Test1
    {
        public partial class MainWindow : Window
        {
            CustomShape customShape = new CustomShape();
    
            public MainWindow()
            {
                InitializeComponent();
    
                customShape.Fill = Brushes.Blue;
                cnvMain.Children.Add(customShape);
            }
    
            private void ButtonAnimate_Clicked(object sender, RoutedEventArgs e)
            {
                DoubleAnimation rec1Animation = new DoubleAnimation(500, TimeSpan.FromSeconds(1));
                customShape.BeginAnimation(CustomShape.Rec1YProperty, rec1Animation);
    
                DoubleAnimation rec2Animation = new DoubleAnimation(360, TimeSpan.FromSeconds(1));
                customShape.BeginAnimation(CustomShape.Rec2RotateProperty, rec2Animation);
    
                DoubleAnimation rec3Animation = new DoubleAnimation(400, TimeSpan.FromSeconds(1));
                customShape.BeginAnimation(CustomShape.Rec3WidthProperty, rec3Animation);
            }
        }
    
        class CustomShape : Shape
        {
            private Rect rect1, rect2, rect3;
            private RectangleGeometry rg1, rg2, rg3;
            private GeometryGroup allRectangleGeometries = new GeometryGroup();
    
            public double Rec1Y
            {
                get { return (double)GetValue(Rec1YProperty); }
                set { SetValue(Rec1YProperty, value); }
            }
            public static readonly DependencyProperty Rec1YProperty =
                DependencyProperty.Register("Rec1Y", typeof(double), typeof(CustomShape), new PropertyMetadata(20d, new PropertyChangedCallback(OnAnyPropertyChanged)));
    
            public double Rec2Rotate
            {
                get { return (double)GetValue(Rec2RotateProperty); }
                set { SetValue(Rec2RotateProperty, value); }
            }
            public static readonly DependencyProperty Rec2RotateProperty =
                DependencyProperty.Register("Rec2Rotate", typeof(double), typeof(CustomShape), new PropertyMetadata(0d, new PropertyChangedCallback(OnAnyPropertyChanged)));
    
            public double Rec3Width
            {
                get { return (double)GetValue(Rec3WidthProperty); }
                set { SetValue(Rec3WidthProperty, value); }
            }
            public static readonly DependencyProperty Rec3WidthProperty =
                DependencyProperty.Register("Rec3Width", typeof(double), typeof(CustomShape), new PropertyMetadata(200d, new PropertyChangedCallback(OnAnyPropertyChanged)));
    
            //Constructor
            public CustomShape()
            {
                makeCustomShape();
            }
    
            private void makeCustomShape()
            {
                rect1 = new Rect(50, Rec1Y, 100, 50);
                rg1 = new RectangleGeometry(rect1);
                allRectangleGeometries.Children.Add(rg1);
    
                rect2 = new Rect(200, 20, 60, 20);
                rg2 = new RectangleGeometry(rect2);
                rg2.Transform = new RotateTransform(Rec2Rotate, 230, 30);
                allRectangleGeometries.Children.Add(rg2);
    
                rect3 = new Rect(300, 20, Rec3Width, 80);
                rg3 = new RectangleGeometry(rect3);
                allRectangleGeometries.Children.Add(rg3);
            }
    
            private static void OnAnyPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
            {           
                CustomShape customShape = source as CustomShape;
                customShape.allRectangleGeometries.Children.Clear();
                customShape.makeCustomShape();
            }
    
            protected override Geometry DefiningGeometry
            {
                get
                {
                    return allRectangleGeometries;
                }
            }
        }
    }
