    public void FillClass(List<StorageFile> files, List<BaseClass> listToFill, int? someOtherInt = null)
    {
        BaseClass item;
        foreach (var file in files)
        {
            if (someOtherInt.HasValue)
                item = new DerivedClass(file.Name.Count(), file.Path.Count(),someOtherInt.Value);
            else
                item = new BaseClass(file.Name.Count(), file.Path.Count());
           
            item.DoSomeCalculation();
            listToFill.Add(item);
        }
    }
