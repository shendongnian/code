        get
        {
            var formats = new ObservableCollection<PrintDocumentSettingsModel>(
                _AllPrintingFormats.Where(x => x.IsStandartPrinter == IsStandartPrinter));
            if (!formats.Contains(SelectedFormat))
                SelectedFormat = formats.FirstOrDefault();
            return formats;
        }
        set { _AllPrintingFormats = value; OnPropertyChanged("PrintingFormats"); }
