         // Create a column for the Pass Fail.
         currentColumn = new DataGridTextColumn();
         currentColumn.Header = "Pass Fail";
         currentColumn.Binding = new Binding("PassFail") { Converter = new BooleanToPassFailConverter() };
         // Create cellstyle to make the cell 'red' when the PassFail value is False. ( this is done via a data trigger )
         cellStyle = new Style(typeof(DataGridCell));
         // Define First DataTrigger that sets a CELL red if the value is a fail.
         dataTrigger = new DataTrigger();
         dataTrigger.Value = "False";
         dataTrigger.Binding = new Binding("PassFail");
         dataTrigger.Setters.Add(setterResultFail);
         // Add the data-triggers to the cell style.
         cellStyle.Triggers.Clear();
         cellStyle.Triggers.Add(dataTrigger);
         //root visual of the ControlTemplate for DataGridCell is a Border
         var border = new FrameworkElementFactory(typeof(Border));
         border.SetBinding(Border.BorderBrushProperty, new Binding("BorderBrush")
         {
               RelativeSource = RelativeSource.TemplatedParent
         });
         border.SetBinding(Border.BackgroundProperty, new Binding("Background") { RelativeSource = RelativeSource.TemplatedParent });
         border.SetBinding(Border.BorderThicknessProperty, new Binding("BorderThickness") { RelativeSource = RelativeSource.TemplatedParent });
         border.SetValue(SnapsToDevicePixelsProperty, true);
         //the only child visual of the border is the ContentPresenter
         var contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
         contentPresenter.SetBinding(SnapsToDevicePixelsProperty, new Binding("SnapsToDevicePixelsProperty") { RelativeSource = RelativeSource.TemplatedParent });
         contentPresenter.SetBinding(VerticalAlignmentProperty, new Binding("VerticalContentAlignment") { RelativeSource = RelativeSource.TemplatedParent });
         contentPresenter.SetBinding(HorizontalAlignmentProperty, new Binding("HorizontalContentAlignment") { RelativeSource = RelativeSource.TemplatedParent });
         //add the child visual to the root visual
         border.AppendChild(contentPresenter);
         //here is the instance of ControlTemplate for DataGridCell
         var template = new ControlTemplate(typeof(DataGridCell));
         template.VisualTree = border;
                    
         //define the style
         cellStyle.Setters.Add(new Setter(TemplateProperty, template));
         cellStyle.Setters.Add(new Setter(VerticalContentAlignmentProperty, VerticalAlignment.Center));
         cellStyle.Setters.Add(new Setter(HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
                 
         // Apply the newly created cell style.
         currentColumn.CellStyle = cellStyle;
