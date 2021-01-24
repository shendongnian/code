    var gridView = new GridView();
            FrameworkElementFactory FEF = new FrameworkElementFactory(typeof(CheckBox));
            FEF.AddHandler(CheckBox.ClickEvent, new RoutedEventHandler(CheckBox_CheckChanged), true);
            Binding CBG = new Binding("DocNo");
            FEF.SetBinding(CheckBox.ContentProperty, CBG);
            Binding SBG = new Binding
            {
                Path = new PropertyPath("chkBox"),
                Mode = BindingMode.OneWay,
            };
            FEF.SetBinding(CheckBox.IsCheckedProperty, SBG);
            gridView.Columns.Add(new GridViewColumn()
            {
                Header = "CheckBox",
                CellTemplate = new DataTemplate() { VisualTree = FEF }
            });
            gridView.Columns.Add(new GridViewColumn() { Header = "DocNo", DisplayMemberBinding = new Binding("DocNo") });
            gridView.Columns.Add(new GridViewColumn() { Header = "QtyReq", DisplayMemberBinding = new Binding("QtyReq") });
            gridView.Columns.Add(new GridViewColumn() { Header = "price", DisplayMemberBinding = new Binding("Price") });
            _listView.View = gridView;
            for (int i = 0; i < 5; i++)
            {
                _listView.Items.Add(
                    new
                    {
                        chkBox = true,
                        DocNo = i + "test",
                        QtyReq = i + "test",
                        Price = i + "test"
                    }
               );
            }
