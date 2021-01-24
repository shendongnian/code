    private void ValidateUser(string user)
    {
        using (ComplaintsEntities db = new ComplaintsEntities())
        {
            var t = db.AAGetAdminStatus(user).First().UserCount;
        }
    }
