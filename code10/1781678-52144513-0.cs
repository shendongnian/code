    public class ShellViewModel : Conductor<object>
    {
        private readonly IWindowManager window = new WindowManager();
        public void LoadFormOne()
        {
            MessageBox.Show("You are about to activate FirstChildViewModel");
            var model = new FirstChildViewModel();
            ActivateItem(model);
            window.ShowDialog(model);
            //or
            //window.ShowWindow(model); //For non-modal
            bool CloseItemAfterDeactivating = true;
            DeactivateItem(model, CloseItemAfterDeactivating);
        }
    }
