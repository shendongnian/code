    public class LeftClickTextBlock : TextBlock
    {
        public LeftClickTextBlock()
        {
           this.PreviewMouseLeftButtonUp += this.LeftClickTextBlock_PreviewMouseLeftButtonUp;
        } 
        
        private void LeftClickTextBlock_PreviewMouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
           LeftClickTextBlock lcb = sender as LeftClickTextBlock;
           ContextMenu contextMenu = lcb.ContextMenu;
           contextMenu.PlacementTarget = lcb;
           contextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
           contextMenu.IsOpen = true;
        }
    }
