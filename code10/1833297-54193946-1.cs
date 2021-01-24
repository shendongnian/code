    private void OnMouseHover (object sender, MouseEventArgs e)
    {
      var lineSelected = (modelGPZ.GetLineWyList().FirstOrDefault(x => x.isSelected == true));
       ComboBoxItem item = sender as ComboBoxItem;
       if ((double)item.Content == lineSelected.LiniaWyComboBox[0])
       {
        DataContext = this;
        item.ToolTip = "Wartość domyślna -(do poprawy nazwy)-";
        OnPropertyChanged("LiniaWyComboBox");
        OnPropertyChanged("ToolTipText");
        e.Handled = true;
        }
        else
        {
         item.ToolTip = "Suma iloczynów wszystkich kabli";
         OnPropertyChanged("LiniaWyComboBox");
         OnPropertyChanged("ToolTipText");
         e.Handled = true;
         }
        }
