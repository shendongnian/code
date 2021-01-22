    public void DataItemClicked(ShipmentData shipmentData) { 
        // Setup the HintBox 
        if (_dataItemHintBox == null) 
            _dataItemHintBox = HintBox.GetHintBox(ShipmentForm.AsAnObjectThatCanOwn(), 
                                                 _dataShipSelectedPoint, 
                                                 new Size(135, 50), shipmentData.LongDesc, 
                                                 Color.LightSteelBlue); 
        // Beginning to measure the size of the string shipmentData.LongDesc here.
        // Assuming that the initial font size should be 30pt.
        Single fontSize = 30.0F;
        Font f = new Font("fontFamily", fontSize, FontStyle.Regular);
        using (Graphics g = new Graphics()) {
            while (g.MeasureString(shipmentData.LongDesc, f).Width > _dataItemHintBox.Size.Width - 5) {
                --fontSize;
                f = new Font("fontFamily", fontSize, FontStyle.Regular);
            }
        }
 
        // Font property inherited from Panel control.
        _dataItemHintBox.Font = f;
        
        // End of font resizing to fit the HintBox panel.
        _dataItemHintBox.Location = new Point(_dataShipSelectedPoint.X - 100, 
                                              _dataShipSelectedPoint.Y - 50); 
        _dataItemHintBox.MessageText = shipmentData.LongDesc; 
        // It would be nice to set the size right here 
        _dataItemHintBox.Size = _dataItemHintBox.MethodToResizeTheHeightToShowTheWholeString() 
        _dataItemHintBox.Show(); 
    } 
