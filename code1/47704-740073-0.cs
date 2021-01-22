    public partial class ListWindow
    {
        Window displayWindow;
        public void OnListBoxItem_MouseEnter()
        {
            displayWindow = new Window();
            displayWindow.Show();
        }
        public void OnListBoxItem_MouseExit()
        {
            displayWindow.Close();
        }
    }
