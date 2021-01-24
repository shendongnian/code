    List<Category> listResult= yourObservableCollection.GroupBy(c => c.Code)
    .Select(cl=>new Caegory
    {
        Code=cl.First().Code;
        // other parameters of Category here
    }).ToList().Where(w=>w.Count()>1);
    ObservableCollection<Category> result=new ObservableCollection<Category>(listResult);
