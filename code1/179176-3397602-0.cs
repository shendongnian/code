    public List<Inquiry> GetInquiries(int numparam, string myparameter)
    {
        object[] params = new object[7];
        params[numparam] = myparameter;
        reporterRepo.Gettype().GetMethod("GetInquiries").Invoke(reporterRepo, params);
    }
