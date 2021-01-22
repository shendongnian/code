    public static class ChildPopupWindowHelper
    {
        public static void ShowChildWindow(string title, ChildWindowUserControl userControl)
        {
            ChildWindow cw = new ChildWindow()
            {
                Title = title
            };
            cw.Content = userControl;
            cw.Show();
        }
    }
    public class ChildWindowUserControl : UserControl
    {
        public void ClosePopup()
        {
            DependencyObject current = this;
            while (current != null)
            {
                if (current is ChildWindow)
                {
                    (current as ChildWindow).Close();
                }
                current = VisualTreeHelper.GetParent(current);
            }
        }
    }
