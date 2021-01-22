    public static void Update(Enquiry enquiry)
    {
        JobsDataContext db = new JobsDataContext();
    
        var enquiries = from e in db.Enquiries
                        where e.PKID == enquiry.PKID
                        select e;
    
        if (enquiries.Count() < 1)
        {
            db.Enquiries.InsertOnSubmit(enquiry);
        }
        else
        {
            Enquiry updateEnquiry = enquiries.Single();
    
            updateEnquiry.LengthMm = enquiry.LengthMm;
            updateEnquiry.ShippedQty = enquiry.ShippedQty;
            updateEnquiry.StatusCode = enquiry.StatusCode;
        }
    
        db.SubmitChanges();
    }
