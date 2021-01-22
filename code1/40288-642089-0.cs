    protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = (from e in db.Enquiries
                                   select new
                                   {
                                        Id = e.Id,
                                        Name = e.Name,
                                        PublicId = EnquiryMethods.GetPublicId(e.PublicId),
                                        What = e.WorkType.DescriptionText,
                                        Where = e.EnquiryArea.DescriptionText,
                                        Who = e.EnquiryType0.DescriptionText,
                                        When = e.EnquiryTime0.DescriptionText,
                                        PriceRange = e.EnquiryPrice0.DescriptionText,
                                        DisplayPriceRange = e.EnquiryPrice0.Display,
                                        Description = e.Description,
                                        Published = e.EnquiryPublished
                                   });
    
    }
