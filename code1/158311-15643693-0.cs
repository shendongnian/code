    public static class UserAgentParser
    {
    	/// <summary>
    	/// Extracts human readible Operating system name.
    	/// </summary>
    	/// <param name="userAgent">User Agent string from Request.</param>
    	/// <returns>Human readible Operating system name.</returns>
    	public static string GetOperatingSystem(string userAgent)
    	{
    		var clientOsName = string.Empty;
    		if (userAgent.Contains("Windows 98"))
    			clientOsName = "Windows 98";
    		else if (userAgent.Contains("Windows NT 5.0"))
    			clientOsName = "Windows 2000";
    		else if (userAgent.Contains("Windows NT 5.1"))
    			clientOsName = "Windows XP";
    		else if (userAgent.Contains("Windows NT 6.0"))
    			clientOsName = "Windows Vista";
    		else if (userAgent.Contains("Windows NT 6.1"))
    			clientOsName = "Windows 7";
    		else if (userAgent.Contains("Windows NT 6.2"))
    			clientOsName = "Windows 8";
    		else if (userAgent.Contains("Windows"))
    		{
    			clientOsName = GetOsVersion(userAgent, "Windows");
    		}
    		else if (userAgent.Contains("Android"))
    		{
    			clientOsName = GetOsVersion(userAgent, "Android");
    		}
    		else if (userAgent.Contains("Linux"))
    		{
    			clientOsName = GetOsVersion(userAgent, "Linux");
    		}
    		else if (userAgent.Contains("iPhone"))
    		{
    			clientOsName = GetOsVersion(userAgent, "iPhone");
    		}
    		else if (userAgent.Contains("iPad"))
    		{
    			clientOsName = GetOsVersion(userAgent, "iPad");
    		}
    		else if (userAgent.Contains("Macintosh"))
    		{
    			clientOsName = GetOsVersion(userAgent, "Macintosh");
    		}
    		else
    		{
    			clientOsName = "Unknown OS";
    		}
    
    		return clientOsName;
    	}
    
    	private static string GetOsVersion(string userAgent, string osName)
    	{
    		if (userAgent.Split(new[] {osName}, StringSplitOptions.None)[1].Split(new[]{';',')'}).Length != 0)
    			{
    				return string.Format("{0}{1}", osName,userAgent.Split(new[] { osName }, StringSplitOptions.None)[1].Split(new[] { ';', ')' })[0]);
    			}
    
    		return osName;
    	}
    }
    
    [TestFixture]
    public class UserAgentParserTest
    {
    
    	public IEnumerable<TestCaseData> UserAgentStringTestData()
    	{
    		yield return new TestCaseData("Mozilla/5.0 (iPhone; CPU iPhone OS 5_0 like Mac OS X) AppleWebKit/534.46 (KHTML, like Gecko) Version/5.1 Mobile/9A334 Safari/7534.48.3", "iPhone");
    		yield return new TestCaseData("Mozilla/5.0 (iPad; CPU OS 5_0 like Mac OS X) AppleWebKit/534.46 (KHTML, like Gecko) Version/5.1 Mobile/9A334 Safari/7534.48.3", "iPad");
    		yield return new TestCaseData("Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/535.11 (KHTML, like Gecko) Ubuntu/11.04 Chromium/17.0.963.56 Chrome/17.0.963.56 Safari/535.11", "Linux x86_64");
    		yield return new TestCaseData("Mozilla/5.0 (X11; Linux i686) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.56 Safari/535.11", "Linux i686");
    		yield return new TestCaseData("Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.56 Safari/535.11", "Windows 7");
    		yield return new TestCaseData("Mozilla/5.0 (Windows NT 6.0; WOW64) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.56 Safari/535.11", "Windows Vista");
    		yield return
    			new TestCaseData(
    				"Mozilla/5.0 (Windows NT 6.2) AppleWebKit/537.4 (KHTML, like Gecko) Chrome/22.0.1229.94 Safari/537.4", "Windows 8");
    		yield return
    			new TestCaseData(
    				"Mozilla/5.0 (Windows NT 5.1) AppleWebKit/536.3 (KHTML, like Gecko) Chrome/19.0.1063.0 Safari/536.3", "Windows XP");
    		yield return
    			new TestCaseData(
    				"Mozilla/5.0 (Windows; U; Windows NT 5.0; en-US) AppleWebKit/532.0 (KHTML, like Gecko) Chrome/3.0.198 Safari/532.0",
    				"Windows 2000");
    		yield return
    			new TestCaseData(
    				"Mozilla/5.0 (compatible; MSIE 7.0; Windows 98; SpamBlockerUtility 6.3.91; SpamBlockerUtility 6.2.91; .NET CLR 4.1.89;GB)", "Windows 98");
    		yield return
    			new TestCaseData(
    				"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_7_4) AppleWebKit/537.13 (KHTML, like Gecko) Chrome/24.0.1290.1 Safari/537.13",
    				"Macintosh");
    		yield return
    			new TestCaseData(
    				"Mozilla/5.0 (X11; CrOS i686 2268.111.0) AppleWebKit/536.11 (KHTML, like Gecko) Chrome/20.0.1132.57 Safari/536.11",
    				"Unknown OS");
    		yield return
    			new TestCaseData(
    				"Mozilla/5.0 (Linux; U; Android 4.0.3; ko-kr; LG-L160L Build/IML74K) AppleWebkit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30",
    				"Android 4.0.3");
    		yield return
    			new TestCaseData("Mozilla/1.22 (compatible; MSIE 10.0; Windows 3.1)", "Windows 3.1");
    	}
    
    	[Test]
    	[TestCaseSource("UserAgentStringTestData")]
    	public void UserAgentParsesOs(string userAgent, string expectedOs)
    	{
    		Assert.AreEqual(expectedOs, UserAgentParser.GetOperatingSystem(userAgent));
    	}
    }
