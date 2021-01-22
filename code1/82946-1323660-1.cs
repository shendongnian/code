    public class MyTab : System.Windows.Forms.TabControl
    {
        int _currentTab;
        protected override void OnSelecting( TabControlCancelEventArgs e )
        {
            // Some logic here to do cool UI things, perhaps use _currentTab
            // Call the base method
            base.OnSelecting( e );
            // Track a valid selection
            if ( !e.Cancel )
                _currentTab = this.SelectedIndex;            
        }
    }
