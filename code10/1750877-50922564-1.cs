                FrameworkElementFactory factory = new FrameworkElementFactory(typeof(Image));
            factory.SetBinding(Image.SourceProperty, new Binding("Icon"));
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Icon",
                CellTemplate = new DataTemplate() { VisualTree = factory }
            });
