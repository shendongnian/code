        var list1 = List1.GetList1();
        var list2 = List2.GetList12();
        List<ListViewModel> listViewmodelCollection = new List<ListViewModel>();
        ListViewModel listViewmodelInstance = new ListViewModel();
        listViewmodelCollection.AddRange(list1.Select(l => new ListViewModel()
        {
            LocationName = l.LocationName,
            LocationCreatedDate = l.CreatedDate,
            LocationValues1 = l.LocationValues1,
            LocationValues2 = l.LocationValues2
        }));
        for (int i = 0; i < (listViewmodelCollection.Count - 1); i++)
        {
            var itm2 = list2.ElementAt(i);
            if (itm2 != null)
            {
                listViewmodelCollection[i].ContinentName = itm2.ContinentName;
                listViewmodelCollection[i].ContinentCreatedDate = itm2.CreatedDate;
                listViewmodelCollection[i].LocationValues4 = itm2.LocationValues4;
                listViewmodelCollection[i].LocationValues5 = itm2.LocationValues5;
                listViewmodelCollection[i].RA = listViewmodelCollection[i].LocationValues1 + itm2.LocationValues4;
            }
        }
