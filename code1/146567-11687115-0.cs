    public static class GridViewColumnCollection
    {
        public static readonly DependencyProperty ColumnCollectionBehaviourProperty =
            DependencyProperty.RegisterAttached("ColumnCollectionBehaviour", typeof(GridViewColumnCollectionBehaviour), typeof(GridViewColumnCollection), new UIPropertyMetadata(null));
        public static readonly DependencyProperty ColumnsSourceProperty =
            DependencyProperty.RegisterAttached("ColumnsSource", typeof(object), typeof(GridViewColumnCollection), new UIPropertyMetadata(null, GridViewColumnCollection.ColumnsSourceChanged));
        public static readonly DependencyProperty DisplayMemberFormatMemberProperty =
            DependencyProperty.RegisterAttached("DisplayMemberFormatMember", typeof(string), typeof(GridViewColumnCollection), new UIPropertyMetadata(null, GridViewColumnCollection.DisplayMemberFormatMemberChanged));
        public static readonly DependencyProperty DisplayMemberMemberProperty =
            DependencyProperty.RegisterAttached("DisplayMemberMember", typeof(string), typeof(GridViewColumnCollection), new UIPropertyMetadata(null, GridViewColumnCollection.DisplayMemberMemberChanged));
        public static readonly DependencyProperty HeaderTextMemberProperty =
            DependencyProperty.RegisterAttached("HeaderTextMember", typeof(string), typeof(GridViewColumnCollection), new UIPropertyMetadata(null, GridViewColumnCollection.HeaderTextMemberChanged));
        public static readonly DependencyProperty WidthMemberProperty =
            DependencyProperty.RegisterAttached("WidthMember", typeof(string), typeof(GridViewColumnCollection), new UIPropertyMetadata(null, GridViewColumnCollection.WidthMemberChanged));
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static GridViewColumnCollectionBehaviour GetColumnCollectionBehaviour(DependencyObject obj)
        {
            return (GridViewColumnCollectionBehaviour)obj.GetValue(ColumnCollectionBehaviourProperty);
        }
        public static void SetColumnCollectionBehaviour(DependencyObject obj, GridViewColumnCollectionBehaviour value)
        {
            obj.SetValue(ColumnCollectionBehaviourProperty, value);
        }
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static object GetColumnsSource(DependencyObject obj)
        {
            return (object)obj.GetValue(ColumnsSourceProperty);
        }
        public static void SetColumnsSource(DependencyObject obj, object value)
        {
            obj.SetValue(ColumnsSourceProperty, value);
        }
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static string GetDisplayMemberFormatMember(DependencyObject obj)
        {
            return (string)obj.GetValue(DisplayMemberFormatMemberProperty);
        }
        public static void SetDisplayMemberFormatMember(DependencyObject obj, string value)
        {
            obj.SetValue(DisplayMemberFormatMemberProperty, value);
        }
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static string GetDisplayMemberMember(DependencyObject obj)
        {
            return (string)obj.GetValue(DisplayMemberMemberProperty);
        }
        public static void SetDisplayMemberMember(DependencyObject obj, string value)
        {
            obj.SetValue(DisplayMemberMemberProperty, value);
        }
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static string GetHeaderTextMember(DependencyObject obj)
        {
            return (string)obj.GetValue(HeaderTextMemberProperty);
        }
        public static void SetHeaderTextMember(DependencyObject obj, string value)
        {
            obj.SetValue(HeaderTextMemberProperty, value);
        }
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static string GetWidthMember(DependencyObject obj)
        {
            return (string)obj.GetValue(WidthMemberProperty);
        }
        public static void SetWidthMember(DependencyObject obj, string value)
        {
            obj.SetValue(WidthMemberProperty, value);
        }
        private static void ColumnsSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            GridViewColumnCollection.GetOrCreateColumnCollectionBehaviour(sender).ColumnsSource = e.NewValue;
        }
        private static void DisplayMemberFormatMemberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            GridViewColumnCollection.GetOrCreateColumnCollectionBehaviour(sender).DisplayMemberFormatMember = e.NewValue as string;
        }
        private static void DisplayMemberMemberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            GridViewColumnCollection.GetOrCreateColumnCollectionBehaviour(sender).DisplayMemberMember = e.NewValue as string;
        }
        private static void HeaderTextMemberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            GridViewColumnCollection.GetOrCreateColumnCollectionBehaviour(sender).HeaderTextMember = e.NewValue as string;
        }
        private static void WidthMemberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            GridViewColumnCollection.GetOrCreateColumnCollectionBehaviour(sender).WidthMember = e.NewValue as string;
        }
        private static GridViewColumnCollectionBehaviour GetOrCreateColumnCollectionBehaviour(DependencyObject source)
        {
            GridViewColumnCollectionBehaviour behaviour = GetColumnCollectionBehaviour(source);
            if (behaviour == null)
            {
                GridView typedSource = source as GridView;
                if (typedSource == null)
                {
                    throw new Exception("This property can only be set on controls deriving GridView");
                }
                behaviour = new GridViewColumnCollectionBehaviour(typedSource);
                SetColumnCollectionBehaviour(typedSource, behaviour);
            }
            return behaviour;
        }
    }
