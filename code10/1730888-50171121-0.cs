    class myClass {
        
        private bool _shown;
        
        public async void KomikMsgDialog()
        {
            if (!_shown) // If we haven't shown the dialog yet
            {
                MessageDialog messageDialog1 = new MessageDialog("Jumlah komik bertambah sebanyak " + jumlahbuku + " komik pada menu Komik Pendidikan", "Update Berhasil");
                messageDialog1.Commands.Add(new UICommand("OK", (command) =>
                {
                    DownloadBukuVideo.IsOpen = false;
                    Downloading.IsOpen = false;
                    ukomikBtn.Visibility = Visibility.Visible;
                    downloadKomikBtn.Visibility = Visibility.Collapsed;
                    ukomikText.Visibility = Visibility.Collapsed;
                    ukomikText.Text = "";
                }));
                await messageDialog1.ShowAsync();
                _shown = true; // Flag the dialog as having been shown
            }
        }
    }
