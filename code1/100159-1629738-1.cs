    public void UpdateStatus(IQueryable<IStatusInfo> data) {
        IStatusInfo item = data.Single();
        DateTime? theDate = item.CreatedDate;
        string theUser = item.CreatedUser;
    }
