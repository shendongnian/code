public static Dictionary<string, string> LoadConfig(string settingfile)
{
	var dic = new Dictionary<string, string>();
	if (File.Exists(settingfile))
	{
		var settingdata = File.ReadAllLines(settingfile);
		for (var i = 0; i < settingdata.Length; i++)
		{
			var setting = settingdata[i];
			var sidx = setting.IndexOf("=");
			if (sidx >= 0)
			{
				var skey = setting.Substring(0, sidx);
				var svalue = setting.Substring(sidx+1);
				if (!dic.ContainsKey(skey))
				{
					dic.Add(skey, svalue);
				}
			}
		}
	}
	return dic;
}
*Note: I'm using a Dictionary so keys must be unique, which is usually that case with setting.*  
USAGE:
var settingfile = AssemblyDirectory + "\\mycustom.setting";
var settingdata = LoadConfig(settingfile);
if (settingdata.ContainsKey("lastrundate"))
{
	DateTime lout;
	string svalue;
	if (settingdata.TryGetValue("lastrundate", out svalue))
	{
		DateTime.TryParse(svalue, out lout);
		lastrun = lout;
	}
}
