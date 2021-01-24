    public class MyAuditingStore : AuditingStore
    {
        private readonly OtherInformationService _otherInformationService;
        
        public MyAuditingStore(
            IRepository<AuditLog, long> auditLogRepository,
            OtherInformationService otherInformationService)
            : base(auditLogRepository)
        {
            _otherInformationService = otherInformationService;
        }
        public override Task SaveAsync(AuditInfo auditInfo)
        {
            auditInfo.CustomData = otherInformationService.GetOtherInformation();
            return base.SaveAsync(auditInfo);
        }
    }
    public class OtherInformationService : ITransientDependency
    {
        public string GetOtherInformation()
        {
            return "other information";
        }
    }
