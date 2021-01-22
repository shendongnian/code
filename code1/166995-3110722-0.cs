    using System.Windows.Interactivity;
    public class SelectFirstItemComboBoxBehavior : Behavior<ComboBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            (AssociatedObject.Items as INotifyCollectionChanged).CollectionChanged += HandleCollectionChanged;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            (AssociatedObject.Items as INotifyCollectionChanged).CollectionChanged -= HandleCollectionChanged;
        }
        private void HandleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (AssociatedObject.Items.Count == 1)
            {
                AssociatedObject.SelectedItem = AssociatedObject.Items.Cast<object>().First();
            }
        }
    }
