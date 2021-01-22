	private static MethodInfo _cookieEncryptMethod;
	private static MethodInfo _cookieDecryptMethod;
	public static string MachineKeyEncrypt(string data)
	{
		if (_cookieEncryptMethod == null)
		{
			_cookieEncryptMethod = Type.GetType("System.Web.Security.CookieProtectionHelper").GetMethod("Encode", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod);
		}
		var dataBytes = Encoding.UTF8.GetBytes(data);
		return (string) _cookieEncryptMethod.Invoke(null, new object[] { CookieProtection.All, dataBytes, dataBytes.Length });
	}
	public static string MachineKeyDecrypt(string source)
	{
		if (_cookieDecryptMethod == null)
		{
			_cookieDecryptMethod = Type.GetType("System.Web.Security.CookieProtectionHelper").GetMethod("Decode", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod);
		}
		var data = (byte[]) _cookieDecryptMethod.Invoke(null, new object[] { CookieProtection.All, source });
		return Encoding.UTF8.GetString(data);
	}
