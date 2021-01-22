    foreach (ComboBoxItem cbi in someComboBox.Items)
                        {
                            if (cbi.Content as String == "sometextThatShouldbeIntheComboBox")
                            {
                                someComboBox.SelectedItem = cbi;
                                break;
                            }
                        }
