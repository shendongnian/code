    private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue == null)
        {
            SupervisorDropDown.ClearValue(ComboBox.SelectedValueProperty);
        }
    }
