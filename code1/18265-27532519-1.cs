        var settingfile = AssemblyDirectory + "\\mycustom.setting";
        var settingdata = LoadConfig(settingfile);
        if (settingdata.ContainsKey("lastrundate"))
        {
            DateTime lout;
            String svalue;
            if (settingdata.TryGetValue("lastrundate", out svalue))
            {
                DateTime.TryParse(svalue, out lout);
                lastrun = lout;
            }
        }
