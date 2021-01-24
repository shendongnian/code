    public class BehaviorClassName: DependencyObject, IBehavior
    {
        private TextBox _associatedObject;
        private ListView _listView;
    
        public DependencyObject AssociatedObject
        {
            get
            {
                return _associatedObject;
            }
        }
    
        public void Attach(DependencyObject associatedObject)
        {
            _associatedObject = associatedObject as TextBox;
    
            if (_associatedObject != null)
            {
                _associatedObject.KeyDown -= TextBox_OnKeyDown;
                _associatedObject.KeyDown += TextBox_OnKeyDown;
            }
        }
    
        private void TextBox_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (_associatedObject != null)
            {
                if (_listView == null)
                {
                    // Gets ListView through visual tree. That's a hack of course. Had to put it here since the list initializes only after the textbox itself
                    _listView = (ListView)((Border)((Popup)((Grid)_associatedObject.Parent).Children[1]).Child).Child;
                }
                if (e.Key == VirtualKey.Enter && _listView.SelectedItem != null)
                {
                    // Here I had to make sure the Enter key doesn't work only on specific (disabled) items, and still works on all the others
                    // Reflection I had to insert to overcome the missing reference to the needed ViewModel
                    if (!((bool)_listView.SelectedItem.GetType().GetProperty("PropertyByWhichIDisableSpecificItems").GetValue(_listView.SelectedItem, null)))
                        e.Handled = true;
                }
            }
        }
    
        public void Detach()
        {
            _associatedObject.KeyDown -= TextBox_OnKeyDown;
        }
    }
