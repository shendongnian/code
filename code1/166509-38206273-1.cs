    // Two-state CheckBox doesn't require checking null
    if (cbxSwitch.IsChecked == true)
    {
        // Do something if selected
    }
    // In three-state CheckBox, IsChecked may be true, false or null
    if (cbxSwitch3.IsChecked ?? false)
    {
        // Do something only if IsChecked==true (selected)
    }
