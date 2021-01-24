    <ComboBox.ItemContainerStyle >
        <Style TargetType="{x:Type ComboBoxItem}">
            <EventSetter Event="GotFocus"  Handler="ComboBoxItem_GotFocus"/>
        </Style>
    </ComboBox.ItemContainerStyle>
    private void ComboBoxItem_GotFocus(object sender, RoutedEventArgs e)
    {
    	var lineSelected = (modelGPZ.GetLineWyList().FirstOrDefault(x => x.isSelected == true));
    	ComboBoxItem item = sender as ComboBoxItem;
    	if ((double)item.Content == lineSelected.LiniaWyComboBox[0])
    	{
    		item.ToolTip = "This is the first Item";
    	}
    	if ((double)item.Content == lineSelected.LiniaWyComboBox[1])
    	{
    		item.ToolTip = "This is the second Item";
    	}
    }
