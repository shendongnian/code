    FrameworkElementFactory fElement = new FrameworkElementFactory(typeof(ComboBox));
                        fElement.SetValue(ComboBox.WidthProperty, 125D);
                        fElement.SetValue(ComboBox.ItemsSourceProperty, Resultaten);
                        fElement.SetValue(ComboBox.DisplayMemberPathProperty, "Value");
                        fElement.SetValue(ComboBox.SelectedValuePathProperty, "Key");
                        fElement.SetValue(ComboBox.SelectedValueProperty, new Binding(column.ColumnName));
    
                        Style cbStyle = new Style(typeof(ComboBox));
                        Setter cbSetter = new Setter(ComboBox.VisibilityProperty, Visibility.Visible);                  
                        cbStyle.Setters.Add(cbSetter);
    
                        DataTrigger cbDataTrigger = new DataTrigger();
                        Binding cbBinding = new Binding(column.ColumnName);
    
                        cbDataTrigger.Value = 0;
    
                        Setter cbDataSetter = new Setter(ComboBox.VisibilityProperty, Visibility.Hidden);
    
                        cbDataTrigger.Setters.Add(cbDataSetter);
                        cbDataTrigger.Binding = cbBinding;
                        cbStyle.Triggers.Add(cbDataTrigger);               
    
                        fElement.SetValue(ComboBox.StyleProperty, cbStyle);
    
                        DataTemplate dataTemplate = new DataTemplate();
                        dataTemplate.VisualTree = fElement;
                        gvc.CellTemplate = dataTemplate;
