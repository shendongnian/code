    foreach (ComboBoxItem cbi in someComboBox.Items)
                        {
                            if (cbi.Content as String == "sometextIntheComboBox")
                            {
                                someComboBox.SelectedItem = cbi;
                                break;
                            }
                        }
