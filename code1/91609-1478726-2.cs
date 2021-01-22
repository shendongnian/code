    public static String NurseName(Guid? userID)
        {
            var query= from demographic in context.tblDemographics
                            where demographic.UserID == userID
                            select new {FullName = demographic.FirstName +" " + demographic.LastName; }
            var nurseName = query.SingleOrDefault();
            return nurseName != null ? nurseName.FullName : "";
        }
