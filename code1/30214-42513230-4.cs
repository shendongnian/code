    class MainWindowExportToExcelCSV : ICommand
    {
        ...
        public async void Execute(object parameter)
        {
            var usr_ctrl = parameter as UserControl;
            MyFileDialog fd = new MyFileDialog();
            const bool WhenIComeBackIStillNeedToAccessUIObjectAndThusINeedToRetrieveMyOriginalUIContext = true;
            string filename = await fd.ChooseFileFromExtension("CSV files (*.csv)|*.csv|All files (*.*)|*.*").ConfigureAwait(
                WhenIComeBackIStillNeedToAccessUIObjectAndThusINeedToRetrieveMyOriginalUIContext);
            
            Visual visual = (Visual)usr_ctrl.Content;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                //look for datagrid element
            }
        }
    }
