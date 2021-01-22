    partial class ExampleDataContext
    {
        partial void OnCreated()
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.AssociateWith<MyObject>(i => i.Children.OrderBy(c => c.DisplayOrder));
            LoadOptions = dlo;
        }
    }
