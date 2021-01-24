    public class StackPanelOfButtons : UIElement
    {
        public StackPanel stackPanel = new StackPanel();
        public StackPanelOfButtons(List<myButton> buttons)
        {
            buttons.ForEach(b => stackPanel.Children.Add(b.btn)); 
        }
    }
