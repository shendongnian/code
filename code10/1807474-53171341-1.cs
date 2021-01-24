     public interface IEntityViewModel<T>
    {
        T Id { get; set; }
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
        byte[] RowVersion { get; set; }
    }
    public class UrlRecViewModel : IEntityViewModel<Int64>
    {
        public int EntityId { get; set; }
        public string EntityName { get; set; }
        public string Slug { get; set; }
        public bool IsActive { get; set; }
        public int LanguageId { get; set; }
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public byte[] RowVersion { get; set; }
    }
