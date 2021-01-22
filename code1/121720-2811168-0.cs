        private void AttachFilesClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension
            // Show open file dialog box
            bool? result = dlg.ShowDialog();
            // Process open file dialog box results
            if (result == true)
            {
                string filename = dlg.FileName;
                // Invoke the command.
                MyViewModel myViewModel = (MyViewModel)DataContext;
                if (myViewModel .AttachFilesCommand.CanExecute(filename))
                {
                    noteViewModel.AttachFilesCommand.Execute(filename);  
                }
            }
        }
