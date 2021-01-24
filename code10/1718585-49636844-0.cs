    public async void CsvParse()
            {
                var picker = new Windows.Storage.Pickers.FileOpenPicker();
                picker.FileTypeFilter.Add(".csv");
                Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
                if (file != null)
                {
                    IList<string> lines = await FileIO.ReadLinesAsync(file);//this is where app stops working and gives error message.
                }
            }
