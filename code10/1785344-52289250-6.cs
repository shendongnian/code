    public class ShapeItem : Canvas
    {
        public ShapeItem()
        {
            var path = new Path
            {
                Stroke = Brushes.Transparent,
                Fill = Brushes.Transparent
            };
            path.SetBinding(Path.DataProperty,
                new Binding(nameof(Data)) { Source = this });
            path.SetBinding(Shape.StrokeThicknessProperty,
                new Binding(nameof(HitTestStrokeThickness)) { Source = this });
            Children.Add(path);
            path = new Path();
            path.SetBinding(Path.DataProperty,
                new Binding(nameof(Data)) { Source = this });
            path.SetBinding(Shape.FillProperty,
                new Binding(nameof(Fill)) { Source = this });
            path.SetBinding(Shape.StrokeProperty,
                new Binding(nameof(Stroke)) { Source = this });
            path.SetBinding(Shape.StrokeThicknessProperty,
                new Binding(nameof(StrokeThickness)) { Source = this });
            Children.Add(path);
        }
        public static readonly DependencyProperty DataProperty =
            Path.DataProperty.AddOwner(typeof(ShapeItem));
        public static readonly DependencyProperty FillProperty =
            Shape.FillProperty.AddOwner(typeof(ShapeItem));
        public static readonly DependencyProperty StrokeProperty =
            Shape.StrokeProperty.AddOwner(typeof(ShapeItem));
        public static readonly DependencyProperty StrokeThicknessProperty =
            Shape.StrokeThicknessProperty.AddOwner(typeof(ShapeItem));
        public static readonly DependencyProperty HitTestStrokeThicknessProperty =
            DependencyProperty.Register(nameof(HitTestStrokeThickness), typeof(double), typeof(ShapeItem));
        public Geometry Data
        {
            get => (Geometry)GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }
        public Brush Fill
        {
            get => (Brush)GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }
        public Brush Stroke
        {
            get => (Brush)GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }
        public double StrokeThickness
        {
            get => (double)GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }
        public double HitTestStrokeThickness
        {
            get => (double)GetValue(HitTestStrokeThicknessProperty);
            set => SetValue(HitTestStrokeThicknessProperty, value);
        }
    }
    public class ShapeItemsControl : ItemsControl
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ShapeItem();
        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is ShapeItem;
        }
    }
