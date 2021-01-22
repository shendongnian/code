    private static bool SetUseUnsafeHeaderParsing(bool b)
        {
            Assembly a = Assembly.GetAssembly(typeof(System.Net.Configuration.SettingsSection));
            if (a == null) return false;
            Type t = a.GetType("System.Net.Configuration.SettingsSectionInternal");
            if (t == null) return false;
            object o = t.InvokeMember("Section",
                BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic, null, null, new object[] { });
            if (o == null) return false;
            FieldInfo f = t.GetField("useUnsafeHeaderParsing", BindingFlags.NonPublic | BindingFlags.Instance);
            if (f == null) return false;
            f.SetValue(o, b);
            return true;
        }
