    //When Font Size is changed
    private void rbngFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rtbMain.Focus(); // This part is what fixes the issue, just make sure it is set before ApplyPropertyValue method.
            try
            {
                ApplyPropertyValueToSelectedText(TextElement.FontSizeProperty, e.AddedItems[0]);
            }
            catch { };
        }
    //When FontFamily is changed
    private void rbngFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FontFamily editValue = (FontFamily)e.AddedItems[0];
            rtbMain.Focus(); // This part is what fixes the issue, just make sure it is set before ApplyPropertyValue method.
    
            ApplyPropertyValueToSelectedText(TextElement.FontFamilyProperty, editValue);            
            
        }
