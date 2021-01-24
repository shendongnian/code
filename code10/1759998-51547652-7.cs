    public class ExampleUsage
    {
        private readonly CachedLookup<LanguageInfoModel, (string frontendId, string languageId, string accessId)> _lookup 
            = new CachedLookup<LanguageInfoModel, (string frontendId, string languageId, string accessId)>(new LanguageInfoModelComparer());
    
        public ValueTask<List<LanguageInfoModel>> GetLanguagesAsync(string frontendId, string languageId, string accessId)
        {
            return _lookup.GetAsync((frontendId, languageId, accessId), GetLanguagesFromDB(k));
        }
    
        private async Task<List<LanguageInfoModel>> GetLanguagesFromDB((string frontendId, string languageId, string accessId) key) => throw new NotImplementedException();
    }
    
    public class LanguageInfoModel
    {
        public string FrontendId { get; set; }
        public string LanguageId { get; set; }
        public string AccessId { get; set; }
        public string SomeOtherUniqueValue { get; set; }
    }
    
    public class LanguageInfoModelComparer : IEqualityComparer<LanguageInfoModel>
    {
        public bool Equals(LanguageInfoModel x, LanguageInfoModel y)
        {
            return (x?.FrontendId, x?.AccessId, x?.LanguageId, x?.SomeOtherUniqueValue)
                .Equals((y?.FrontendId, y?.AccessId, y?.LanguageId, y?.SomeOtherUniqueValue));
        }
    
        public int GetHashCode(LanguageInfoModel obj) => 
            (obj.FrontendId, obj.LanguageId, obj.AccessId, obj.SomeOtherUniqueValue).GetHashCode();
    }
