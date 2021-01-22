    public class MyTab : System.Windows.Forms.TabControl
    {
        int _previousTab;
        
        protected override void OnSelecting( TabControlCancelEventArgs e )
        {
            // Some logic here to do cool UI things, perhaps use _previousTab
            // Call the base method
            base.OnSelecting( e );           
        }
        protected override void OnDeselecting( TabControlCancelEventArgs e )
        {
            // Store the value for use later in the chain of events
            _previousTab = this.SelectedIndex;
            // Call the base method
            base.OnDeselecting( e );
        }
    }
