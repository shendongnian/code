        public static Dictionary<String, String> LoadConfig(string settingfile)
        {
            var dic = new Dictionary<String, String>();
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
