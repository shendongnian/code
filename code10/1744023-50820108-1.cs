    public interface ISettings
    {
        void DeleteAllSettingsLinkedToSoftware(Guid softwareId);
    }
    
    public sealed class Settings : ISettings
    {
        private readonly IEnumerable<Setting> _settings;
        public Settings(IEnumerable<Setting> settings) => _settings = settings;
        public override void DeleteAllSettingsLinkedToSoftware(Guid softwareGuid)
        {
            foreach(var setting in _settings.Where(s => s.SoftwareId == softwareId))
            {
                setting.IsDeleted = true;
            }
        }
    }
    
    public sealed class EFSettings : ISettings
    {
        private readonly ISettings _source;
        private readonly DBContext _dbContext;
        public EFSettings(DBContext dbContext)
        {
            _dbContext = dbContext;
            _source = new Settings(_dbContext.Settings);
        }
        public override void DeleteAllSettingsLinkedToSoftware(Guid softwareGuid)
        {
            _source.DeleteAllSettingsLinkedToSoftware(softwareGuid);
            _dbContext.SaveChanges();
        }
    }
