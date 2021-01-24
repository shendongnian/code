    public class LinkQualifier : ILinkQualifier
    {
        private readonly IEnumerable<IQualifier> _qualifiers;
        public LinkQualifier(IQualifiersProvider qualifiersProvider)
        {
            _qualifiers = qualifiersProvider.GetQualifiers();
        }
        public IQualifier Qualify(Uri uri)
        {
            return _qualifiers.FirstOrDefault(q => q.CanQualify(uri));
        }
    }
