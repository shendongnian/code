    public class BindableCommandBarBehavior : Behavior<CommandBar>
    {
        public static readonly DependencyProperty PrimaryCommandsProperty = DependencyProperty.Register(
            "PrimaryCommands", typeof(object), typeof(BindableCommandBarBehavior),
            new PropertyMetadata(null, UpdateCommands));
        public static readonly DependencyProperty ItemTemplateSelectorProperty = DependencyProperty.Register(
            "ItemTemplateSelector", typeof(DataTemplateSelector), typeof(BindableCommandBarBehavior),
            new PropertyMetadata(null, null));
        public DataTemplateSelector ItemTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(ItemTemplateSelectorProperty); }
            set { SetValue(ItemTemplateSelectorProperty, value); }
        }
        public object PrimaryCommands
        {
            get { return  GetValue(PrimaryCommandsProperty); }
            set { SetValue(PrimaryCommandsProperty, value); }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (PrimaryCommands is INotifyCollectionChanged notifyCollectionChanged)
            {
                notifyCollectionChanged.CollectionChanged -= PrimaryCommandsCollectionChanged;
            }
        }
        private void UpdatePrimaryCommands()
        {
            if (AssociatedObject == null)
                return;
            if (PrimaryCommands == null)
                return;
            AssociatedObject.PrimaryCommands.Clear();
            if (!(PrimaryCommands is IEnumerable enumerable))
            {
                AssociatedObject.PrimaryCommands.Clear();
                return;
            }
                
            foreach (var command in enumerable)
            {
                var template = ItemTemplateSelector.SelectTemplate(command, AssociatedObject);
                if (!(template?.LoadContent() is FrameworkElement dependencyObject))
                    continue;
                dependencyObject.DataContext = command;
                if (dependencyObject is ICommandBarElement icommandBarElement)
                    AssociatedObject.PrimaryCommands.Add(icommandBarElement);
            }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            UpdatePrimaryCommands();
        }
        private void PrimaryCommandsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdatePrimaryCommands();
        }
        private static void UpdateCommands(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if (!(dependencyObject is BindableCommandBarBehavior behavior)) return;
            if (dependencyPropertyChangedEventArgs.OldValue is INotifyCollectionChanged oldList)
            {
                oldList.CollectionChanged -= behavior.PrimaryCommandsCollectionChanged;
            }
            if (dependencyPropertyChangedEventArgs.NewValue is INotifyCollectionChanged newList)
            {
                newList.CollectionChanged += behavior.PrimaryCommandsCollectionChanged;
            }
            behavior.UpdatePrimaryCommands();
        }
    }
