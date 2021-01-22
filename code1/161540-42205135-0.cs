        private void btnSelect_Click(object sender, RoutedEventArgs e) {
            var dlg = new Microsoft.Win32.OpenFileDialog {
                DefaultExt = ".csv",
                Filter = "Wav Files Only (*.wav)|*.wav",
                InitialDirectory = "C:\\Windows\\Media\\",
                CheckFileExists = true
            };
            dlg.FileName = "preselect the existing file if you wish";
            dlg.FileOk += (s, cancel) => {
                var player = new MediaPlayer();
                player.Open(new Uri(dlg.FileName));
                player.Play();
                var msgres = MessageBox.Show(Path.GetFileName(dlg.FileName)+"\nUse this sound?", "Sound Playing", MessageBoxButton.YesNo);
                if (msgres != MessageBoxResult.Yes) cancel.Cancel = true;
                player.Stop(); //in case it is a long sound
            };
            var result = dlg.ShowDialog();
            if (result != true) return;
            //do whatever with dlg.FileName ...
        }
