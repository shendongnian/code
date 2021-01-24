    public class LocalToUtcResolver : IMemberValueResolver<object, object, DateTime, DateTime>, IMemberValueResolver<object, object, DateTime?, DateTime?>
    {
        private IDateTimeConverter TimeConverter;
        public LocalToUtcResolver(IDateTimeConverter timeConverter)
        {
            TimeConverter = timeConverter;
        }
        public DateTime Resolve(object source, object destination, DateTime sourceMember, DateTime destMember, ResolutionContext context)
        {
            return TimeConverter.LocalToUtc(sourceMember);
        }
        public DateTime? Resolve(object source, object destination, DateTime? sourceMember, DateTime? destMember, ResolutionContext context)
        {
            return TimeConverter.LocalToUtc(sourceMember);
        }
    }
