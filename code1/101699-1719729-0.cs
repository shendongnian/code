    public class SampleSecurity : CommonObjectSecurity
	{
		public SampleSecurity(bool isContainer)
			: base(isContainer)
		{
		}
		public override AccessRule AccessRuleFactory(IdentityReference identityReference, 
			int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, 
			PropagationFlags propagationFlags, AccessControlType type)
		{
			return new SampleAccessRule(identityReference, accessMask, type);
		}
		public void AddAccessRule(IdentityReference identityReference, 
			int accessMask, AccessControlType type)
		{
			base.AddAccessRule(new ProxyAccessRule(identityReference, accessMask, type));
		}
		public void RemoveAccessRule(ProxyAccessRule rule)
		{
			base.RemoveAccessRule(rule);
		}
		
		public override Type AccessRuleType
		{
			get { return typeof(ProxyAccessRule); }
		}
		public override AuditRule AuditRuleFactory(System.Security.Principal.IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags)
		{
			throw new NotImplementedException();
		}
		public override Type AuditRuleType
		{
			get { throw new NotImplementedException(); }
		}
                public override Type AccessRightType
		{
			get { return typeof(SampleRightsEnum); }
		}
	}
	public class SampleAccessRule : AccessRule
	{
		public ProxyAccessRule(IdentityReference identity, int accessMask, AccessControlType accessType)
            : base(identity, accessMask, false, InheritanceFlags.None, PropagationFlags.None, accessType)
        {
        }
		public int AccessRights { get { return AccessMask; } }
	}
        public enum SampleRightsEnum
	{
		sampleRead = 0x001,
		sampleWrite = 0x002,
		sampleExecute = 0x004
	}
