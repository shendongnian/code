      sealed class ChatFlowDocumentBehavior : Behavior<FlowDocument>
      {
        // This is our dependency property for the messages
        public static readonly DependencyProperty MessagesProperty =
          DependencyProperty.Register(
            nameof(Messages),
            typeof(ObservableCollection<string>),
            typeof(ChatFlowDocumentBehavior),
            new PropertyMetadata(defaultValue: null, MessagesChanged));
    
        public ObservableCollection<string> Messages
        {
          get => (ObservableCollection<string>)GetValue(MessagesProperty);
          set => SetValue(MessagesProperty, value);
        }
    
        // This defines how our items will look like
        public DataTemplate ItemTemplate { get; set; }
    
        // This method will be called by the framework when the behavior attaches to flow document
        protected override void OnAttached()
        {
          RefreshMessages();
        }
    
        private static void MessagesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
          if (!(d is ChatFlowDocumentBehavior b))
          {
            return;
          }
    
          if (e.OldValue is ObservableCollection<string> oldValue)
          {
            oldValue.CollectionChanged -= b.MessagesCollectionChanged;
          }
    
          if (e.NewValue is ObservableCollection<string> newValue)
          {
            newValue.CollectionChanged += b.MessagesCollectionChanged;
          }
    
          // When the binding engine updates the dependency property value,
          // update the flow doocument
          b.RefreshMessages();
        }
    
        private void MessagesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
          switch (e.Action)
          {
            case NotifyCollectionChangedAction.Add:
              AddNewItems(e.NewItems.OfType<string>());
              break;
    
            case NotifyCollectionChangedAction.Reset:
              AssociatedObject.Blocks.Clear();
              break;
          }
        }
    
        private void RefreshMessages()
        {
          if (AssociatedObject == null)
          {
            return;
          }
    
          AssociatedObject.Blocks.Clear();
          if (Messages == null)
          {
            return;
          }
    
          AddNewItems(Messages);
        }
    
        private void AddNewItems(IEnumerable<string> items)
        {
          foreach (var message in items)
          {
            // If the template was provided, create an instance from the template;
            // otherwise, create a default non-styled paragraph instance
            var newItem = (Paragraph)(ItemTemplate?.LoadContent() as Fragment)?.Content ?? new Paragraph();
            // This inserts the message text directly into the paragraph as an inline item.
            // You might want to change this logic.
            newItem.Inlines.Add(message);
            AssociatedObject.Blocks.Add(newItem);
          }
        }
      }
