    internal static class CasPolicyHelper
	{
		private static bool? _isCasPolicyEnabled;
		internal static bool IsCasPolicyEnabled
		{
			get
			{
				if (_isCasPolicyEnabled == null)
				{
					HostSecurityManager hostSecurityManager = new HostSecurityManager();
					try
					{
						PolicyLevel level = hostSecurityManager.DomainPolicy;
						_isCasPolicyEnabled = true;
					}
					catch (NotSupportedException)
					{
						_isCasPolicyEnabled = false;
					}
				}
				return _isCasPolicyEnabled.Value;
			}
		}
	}
