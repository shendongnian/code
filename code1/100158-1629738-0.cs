    interface IStatusInfo {
        DateTime? CreatedDate { get; }
        string CreatedUser { get; }
    }
    public void UpdateStatus<T>(IQueryable<T> data) where T : IStatusInfo {
        T item = data.Single();
        DateTime? theDate = item.CreatedDate;
        string theUser = item.CreatedUser;
    }
