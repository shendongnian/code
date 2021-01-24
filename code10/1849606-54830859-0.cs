    public static void Main()
	{
		var token = "CfDJ8ON8hfMagqZNkicGHBXln5hi6kj4TCMMaxS5SaaU4BzEgFlKev1mT2gsij7gh2AkG8G+00t4n/PGwX6oQCvnpHk+wIGc1y8ycNbnzGpwW9Q8fwRlZDGQcIMtSCmX7LXwRS0iHSXgDF1O/QcDNGKbIMMZdcfMKYwnnzmUpmNxvZtG0JCYu5o754Y83VEtdbKASlzQz4aFxOUulvHRBQc3xRi2r0N8yveg26FO+RJ9khsqxKGRu4JDDVNWkpguXeVJvA==";
		var newToken = HttpUtility.UrlEncode(token);
		Console.WriteLine(newToken);
		//this will print newToken without +
		var originalToken = HttpUtility.UrlDecode(newToken);
		//this will print original token, with +
		Console.WriteLine(originalToken);
	}
