    public List<Requirement> listInquiryLogged()
    {
        using (DataClassesDataContext dt = new DataClassesDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString))
        {
            var inq = new int[] {1683,1684,1685,1686,1687,1688,1688,1689,1690,1691,1692,1693};
            var result = from Q in dt.Requirements
                         where inq.Contains(Q.ID)
                         orderby Q.Description
                         select Q;
            return result.ToList<Requirement>();
        }
    }
