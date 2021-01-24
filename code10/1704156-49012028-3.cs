    DateTimePicker myPicker = new DateTimePicker { Name = "txtPaymentDate", 
                                                   Location = new Point(146, 232), 
                                                   Size = new Size(113, 20), 
                                                   Format = DateTimePickerFormat.Custom, 
                                                   CustomFormat = " ", 
                                                   TabStop = false };
    myPicker.CloseUp += myPicker_CloseUp;
    Controls.Add(myPicker);
    private void myPicker_CloseUp(object sender, EventArgs e)
    {
        if (sender is DateTimePicker)
        {
           ((DateTimePicker)sender).Format = 'dd-MM-yyyy'; 
        }
    }
