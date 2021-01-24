    public interface ITagProvider
    {
        string GetETag(string tagKey);
        void InvalidateETag(string tagKey);
    }
