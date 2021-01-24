    private void OnMouseHover (object sender, MouseEventArgs e)
    {
      var lineSelected = (modelGPZ.GetLineWyList().FirstOrDefault(x => x.isSelected == true));
       ComboBoxItem item = sender as ComboBoxItem;
       if ((double)item.Content == lineSelected.LiniaWyComboBox[0])
       {
        item.ToolTip = "Item number one";
        }
        else
        {
         item.ToolTip = "Item number two";
         }
        }
