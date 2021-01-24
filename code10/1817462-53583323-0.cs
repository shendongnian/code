      @(Html.Kendo().Grid<WebPortal.Controllers.upcReturnData>().Name("gridCustomers")
                                                     .Columns(
                                        c =>
                                        {
                                            c.Bound(e => e.upc).Title("UPC");
    
                                        })
                                        .Scrollable()
                                        .Resizable(resize => resize.Columns(true))
                                        .DataSource(source =>
                                        {
                                            source.Custom()
                                            .Transport(transport =>
                                            {
                                                transport.Read("GetUPCs", "upc2");
                                            }).Schema(schema =>
                                            {
                                                schema.Data("dataReturned");
    
                                            });
                                        })
