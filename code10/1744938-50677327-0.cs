    (control as DatePicker).FontSize = 24;
    (control as DatePicker).FontWeight = FontWeights.Light;
    (control as DatePicker).MinWidth = 450;
    (control as DatePicker).VerticalAlignment = VerticalAlignment.Center;
    (control as DatePicker).Loaded += (ss, ee) =>
    {
        DatePicker dp = (DatePicker)ss;
        System.Windows.Controls.Primitives.Popup popup = dp.Template.FindName("PART_Popup", dp) as System.Windows.Controls.Primitives.Popup;
        Button button = dp.Template.FindName("PART_Button", dp) as Button;
        if (popup != null && button != null)
            popup.PlacementTarget = button;
    };
