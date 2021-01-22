        public class Diagram : MultiSelector
        {
            public Diagram()
            {
               this.CanSelectMultipleItems = true;
    
    
                // The canvas supports absolute positioning
                FrameworkElementFactory panel = new FrameworkElementFactory(typeof(Canvas)); 
                this.ItemsPanel = new ItemsPanelTemplate(panel);
    
    
                // Tells the container where to position the items
               this.ItemContainerStyle = new Style();
                this.ItemContainerStyle.Setters.Add(new Setter(Canvas.LeftProperty, new Binding("X")));
                this.ItemContainerStyle.Setters.Add(new Setter(Canvas.TopProperty, new Binding("Y")));
            }
    
    
            protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
            {
                FrameworkElement contentitem = element as FrameworkElement;
                Binding leftBinding = new Binding("XProperty");
                leftBinding.Source = contentitem;
                Binding topBinding = new Binding("YProperty");
                topBinding.Source = contentitem;
                contentitem.SetBinding(Canvas.LeftProperty, leftBinding);
                contentitem.SetBinding(Canvas.TopProperty, topBinding);
                base.PrepareContainerForItemOverride(element, item);
            }
 
     public class DiagramItem : ContentControl
     {
           public static readonly DependencyProperty XProperty;
           public static readonly DependencyProperty YProperty;
           public static readonly RoutedEvent SelectedEvent;
           public static readonly RoutedEvent UnselectedEvent;
           public static readonly DependencyProperty IsSelectedProperty;
           public DiagramItem()
           {
           }
           static DiagramItem()
           {
                XProperty = DependencyProperty.Register("XProperty", typeof(Double), typeof(DiagramItem));
                YProperty = DependencyProperty.Register("YProperty", typeof(Double), typeof(DiagramItem));
                SelectedEvent = MultiSelector.SelectedEvent.AddOwner(typeof(DiagramItem));
                UnselectedEvent = MultiSelector.SelectedEvent.AddOwner(typeof(DiagramItem));
                IsSelectedProperty = MultiSelector.IsSelectedProperty.AddOwner(typeof(DiagramItem));
           }
           public Double X
           {
                get
                {
                    return (Double)this.GetValue(XProperty);
                }
                set
                {
                    this.SetValue(XProperty, value);
                }
           }
           public Double Y
           {
                get
                {
                    return (Double)this.GetValue(YProperty);
                }
                set
                {
                     this.SetValue(YProperty, value);
                }
            }
        
            public Point Location
            {
                get
                {
                    return new Point(X, Y);
                }
                set
                {
                    this.X = value.X;
                    this.Y = value.Y;
                }
            }
        }
