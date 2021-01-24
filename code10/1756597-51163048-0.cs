    //Create the factory
    FilterFactory factory = new FilterFactory();
    //Create the filter using the factory
    FilterPanel filter = factory.CreateFilterPanel("invoice");
    //Call the public member on the returned filter
    filter.ClickFilterButtons();
    //To access InvoiceFilter specific stuff you need to cast
    if(filter is InvoiceFilter) {
        (filter as InvoiceFilter).InvoiceStuff();
    }
