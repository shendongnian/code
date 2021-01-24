    var list = new List<ProductSpecification>();
    
    while (reader.Read())
    {
        list.Add(new ProductSpecification()
                                {
                                    //Here I am setting values of fields from reader[xx]. No parsing/converting errors in here.
                                    //Also tried Dispatcher in here, but it throws exception "Invalid attempt to call MetaData while reader is closed"
                                });
    } 
    
    ProductSpecificationList = new ObservableCollection<ProductSpecification>(list);
