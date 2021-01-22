    public class PersistGroupExpandedStateBehavior : Behavior<Expander>
    {
        #region Static Fields
        public static readonly DependencyProperty GroupNameProperty = DependencyProperty.Register(
            "GroupName", 
            typeof(object), 
            typeof(PersistGroupExpandedStateBehavior), 
            new PropertyMetadata(default(object)));
        private static readonly DependencyProperty ExpandedStateStoreProperty =
            DependencyProperty.RegisterAttached(
                "ExpandedStateStore", 
                typeof(IDictionary<object, bool>), 
                typeof(PersistGroupExpandedStateBehavior), 
                new PropertyMetadata(default(IDictionary<object, bool>)));
        #endregion
        #region Public Properties
        public object GroupName
        {
            get
            {
                return (object)this.GetValue(GroupNameProperty);
            }
            set
            {
                this.SetValue(GroupNameProperty, value);
            }
        }
        #endregion
        #region Methods
        protected override void OnAttached()
        {
            base.OnAttached();
            bool? expanded = this.GetExpandedState();
            if (expanded != null)
            {
                this.AssociatedObject.IsExpanded = expanded.Value;
            }
            this.AssociatedObject.Expanded += this.OnExpanded;
            this.AssociatedObject.Collapsed += this.OnCollapsed;
        }
        protected override void OnDetaching()
        {
            this.AssociatedObject.Expanded -= this.OnExpanded;
            this.AssociatedObject.Collapsed -= this.OnCollapsed;
            base.OnDetaching();
        }
        private ItemsControl FindItemsControl()
        {
            DependencyObject current = this.AssociatedObject;
            while (current != null && !(current is ItemsControl))
            {
                current = VisualTreeHelper.GetParent(current);
            }
            if (current == null)
            {
                return null;
            }
            return current as ItemsControl;
        }
        private bool? GetExpandedState()
        {
            var dict = this.GetExpandedStateStore();
            if (!dict.ContainsKey(this.GroupName))
            {
                return null;
            }
            return dict[this.GroupName];
        }
        private IDictionary<object, bool> GetExpandedStateStore()
        {
            ItemsControl itemsControl = this.FindItemsControl();
            if (itemsControl == null)
            {
                throw new Exception(
                    "Behavior needs to be attached to an Expander that is contained inside an ItemsControl");
            }
            var dict = (IDictionary<object, bool>)itemsControl.GetValue(ExpandedStateStoreProperty);
            if (dict == null)
            {
                dict = new Dictionary<object, bool>();
                itemsControl.SetValue(ExpandedStateStoreProperty, dict);
            }
            return dict;
        }
        private void OnCollapsed(object sender, RoutedEventArgs e)
        {
            this.SetExpanded(false);
        }
        private void OnExpanded(object sender, RoutedEventArgs e)
        {
            this.SetExpanded(true);
        }
        private void SetExpanded(bool expanded)
        {
            var dict = this.GetExpandedStateStore();
            dict[this.GroupName] = expanded;
        }
        #endregion
    }
