    public interface IUser
    {
        string DocumentId { get; set; }
        DateTimeOffset Created { get; set; }
        DateTimeOffset Modified { get; set; }
        string Email { get; set; }
        ...
    }
