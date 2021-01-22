        public static void SetDefaultCulture(CultureInfo culture)
        {
            Type type = typeof (CultureInfo);
            try
            {
                // Class "ReflectionContext" exists from .NET 4.5 onwards.
                if (Type.GetType("System.Reflection.ReflectionContext", false) != null)
                {
                    type.GetProperty("DefaultThreadCurrentCulture")
                        .SetValue(System.Threading.Thread.CurrentThread.CurrentCulture,
                            culture, null);
                    type.GetProperty("DefaultThreadCurrentUICulture")
                        .SetValue(System.Threading.Thread.CurrentThread.CurrentCulture,
                            culture, null);
                }
                else //.NET 4 and lower
                {
                    type.InvokeMember("s_userDefaultCulture",
                        BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                        null,
                        culture,
                        new object[] {culture});
                    type.InvokeMember("s_userDefaultUICulture",
                        BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                        null,
                        culture,
                        new object[] {culture});
                    type.InvokeMember("m_userDefaultCulture",
                        BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                        null,
                        culture,
                        new object[] {culture});
                    type.InvokeMember("m_userDefaultUICulture",
                        BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                        null,
                        culture,
                        new object[] {culture});
                }
            }
            catch
            {
                // ignored
            }
        }
    }
