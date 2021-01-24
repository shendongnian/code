    SinglePackResultList = new ObservableCollection<Pack>();
    
    SendRequestCmd = new RelayCommand((object z) =>
    {
        try
        {
            SinglePackResultList.Add(
                SOAPRequest.SOAPRequestHandler(
                    new Pack()
                    {
                        ProductCode = ProductCode_SinglePack,
                        BatchID = BatchID_SinglePack,
                        BatchExpiry = BatchExpiry_SinglePack,
                        PackSerialnumber = SerialNumber_SinglePack,
                        PackTransaction = Transaction_SinglePack.TransactionID
                    }
                )
            );
        }
        catch (Exception e)
        {
            return;
        }
    },
    CanExecute);
