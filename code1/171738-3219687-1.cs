    Hashtable list = new Hashtable();
            foreach (TimeZoneInfo tzi in TimeZoneInfo.GetSystemTimeZones())
            {
                string name = tzi.DisplayName;
                DateTime localtime = TimeZoneHelper.GetLocalTime(tzi.Id);
                list.Add(name, localtime);
            }
