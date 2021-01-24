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
