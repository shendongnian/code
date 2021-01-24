     public ICollectionView /*List<DTOClass>*/ FilterView(DTOClass[] DTO)
     {
        List<Predicate<IEnumerable<DTOClass[]>>>FilteredView = new 
        List<Predicate<IEnumerable<DTOClass[]>>>();
                
        FilteredView.Clear();
        if (Stock_CheckBox.IsChecked != null)
        {
        FilteredView.Add(new Predicate<IEnumerable<DTOClass[]>>(x => x.Where(item => item.stock_symbol == Stock_ComboBoxText)));
        }
    }
