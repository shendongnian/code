    public static string RemoveParentIdPrefix(string pnpDeviceId)
	{
		int iSplit = pnpDeviceId.LastIndexOf("\\", StringComparison.InvariantCulture);
		string part1 = pnpDeviceId.Substring(0, iSplit);
		string part2 = pnpDeviceId.Substring(iSplit);
		int ampersandCount = 0;
		for (int i = part2.Length - 1; i >= 0; i--)
		{
			if (part2[i] == '&')
			{
				ampersandCount++;
			}
			if (ampersandCount == 2)
			{
				part2 = part2.Substring(i + 1);
				break;
			}
		}
		return part1 + "\\" + part2;
	}
