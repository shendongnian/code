    private static void SetWidthFromItems(this ComboBox comboBox)
    {
        if (comboBox.Template.FindName("PART_Popup", comboBox) is Popup popup 
            && popup.Child is FrameworkElement popupContent)
        {
            popupContent.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            // suggested in comments, original answer has a static value 19.0
            var emptySize = SystemParameters.VerticalScrollBarWidth + comboBox.Padding.Left + comboBox.Padding.Right;
            comboBox.Width = emptySize + popupContent.DesiredSize.Width;
        }
    }
