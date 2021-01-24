     List<Predicate<DTOClass>> FilteredView = new List<Predicate<DTOClass>>();
                if (Stock_CheckBox.IsChecked != null)
                {
                    for (int i = 0; i < DTO.Length; i++)
                    {
                        FilteredView.Add(new Predicate<DTOClass>(x => x.stock_symbol == _Stock_ComboBoxText));
                        //FilteredView.Add(new Predicate<DTOClass[]>>(x => x.stock_symbol == _Stock_ComboBoxText));
                    }
                }
