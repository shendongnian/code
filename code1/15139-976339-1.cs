    using System;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace LiveContext.Designer.GUI.Components {
        public class AutoScrollPreventer : StackPanel
        {
        public AutoScrollPreventer() {
            this.RequestBringIntoView += delegate(object sender, RequestBringIntoViewEventArgs e)
            {
                // stop this event from bubbling so that a scrollviewer doesn't try to BringIntoView..
                e.Handled = true;
            };
 
        }
    }
