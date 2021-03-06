    public static DataTable GetImmunizations(int haReviewID)
    {
        using (var context = McpDataContext.Create())
        {
            var currentImmunizations =
                from haReviewImmunization in context.tblHAReviewImmunizations
                where haReviewImmunization.HAReviewID == haReviewID
                join maintItem in context.tblMaintItems
                on haReviewImmunization.ImmunizationMaintID 
                equals maintItem.ItemID
 
                join maintItem2 in context.tblMaintItems
                on haReviewImmunization.ImmunizationReasonID 
                equals maintItem2.ItemID into g
                from maintItem3 in g.DefaultIfEmpty()
 
                select new
                {
                    haReviewImmunization.ImmunizationDate,
                    haReviewImmunization.ImmunizationOther,
                    maintItem.ItemDescription,
                    Reason = maintItem3 == null ? " " : maintItem3.ItemDescription
                };
    
            return currentImmunizations.CopyLinqToDataTable();
        }
    }
