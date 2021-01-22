    public static DataTable GetImmunizations(int haReviewID)
    {
        using (var context = McpDataContext.Create())
        {
            var currentImmunizations =
                from haReviewImmunization in context.tblHAReviewImmunizations
                where haReviewImmunization.HAReviewID == haReviewID
                join maintItem in context.tblMaintItems
                    on haReviewImmunization.ImmunizationMaintID 
                    equals maintItem.ItemID into g
                from maintItem in g
 
                 join maintItem2 in context.tblMaintItems
                    on haReviewImmunization.ImmunizationReasonID 
                    equals maintItem2.ItemID into h
                from maintItem2 in h.DefaultIfEmpty()
 
                select new
                {
                    haReviewImmunization.ImmunizationDate,
                    haReviewImmunization.ImmunizationOther,
                    maintItem.ItemDescription,
                    Reason = maintItem2 == null ? " " : maintItem2.ItemDescription
                };
    
            return currentImmunizations.CopyLinqToDataTable();
        }
    }
