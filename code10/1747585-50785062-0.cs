           if (Settings.Default.MyStringCollection== null)
            {
                Settings.Default.MyStringCollection= new System.Collections.Specialized.StringCollection();
                Settings.Default.MyStringCollection.Add("string1");
                Settings.Default.MyStringCollection.Add("string2");
                Settings.Default.Save();
            }
            else
            {
                var result = Settings.Default.MyStringCollection;
            }
