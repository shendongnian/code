    namespace Ionic.ExampleCode
    {
        public partial class NameOfYourForm
        {
            private void SaveFormToRegistry()
            {
                if (AppCuKey != null)
                {
                    // the completion list
                    var converted = _completions.ToList().ConvertAll(x => x.XmlEscapeIexcl());
                    string completionString = String.Join("¡", converted.ToArray());
                    AppCuKey.SetValue(_rvn_Completions, completionString);
                }
            }
            private void FillFormFromRegistry()
            {
                if (!stateLoaded)
                {
                    if (AppCuKey != null)
                    {
                        // get the MRU list of .... whatever
                        _completions = new System.Windows.Forms.AutoCompleteStringCollection();
                        string c = (string)AppCuKey.GetValue(_rvn_Completions, "");
                        if (!String.IsNullOrEmpty(c))
                        {
                            string[] items = c.Split('¡');
                            if (items != null && items.Length > 0)
                            {
                                //_completions.AddRange(items);
                                foreach (string item in items)
                                    _completions.Add(item.XmlUnescapeIexcl());
                            }
                        }
                        // Can also store/retrieve items in the registry for
                        //   - textbox contents
                        //   - checkbox state
                        //   - splitter state
                        //   - and so on
                        //
                        stateLoaded = true;
                    }
                }
            }
            private Microsoft.Win32.RegistryKey AppCuKey
            {
                get
                {
                    if (_appCuKey == null)
                    {
                        _appCuKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(AppRegistryPath, true);
                        if (_appCuKey == null)
                            _appCuKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(AppRegistryPath);
                    }
                    return _appCuKey;
                }
                set { _appCuKey = null; }
            }
            private string _appRegistryPath;
            private string AppRegistryPath
            {
                get
                {
                    if (_appRegistryPath == null)
                    {
                        // Use a registry path that depends on the assembly attributes,
                        // that are presumed to be elsewhere. Example:
                        // 
                        //   [assembly: AssemblyCompany("Dino Chiesa")]
                        //   [assembly: AssemblyProduct("XPathVisualizer")]
                        var a = System.Reflection.Assembly.GetExecutingAssembly();
                        object[] attr = a.GetCustomAttributes(typeof(System.Reflection.AssemblyProductAttribute), true);
                        var p = attr[0] as System.Reflection.AssemblyProductAttribute;
                        attr = a.GetCustomAttributes(typeof(System.Reflection.AssemblyCompanyAttribute), true);
                        var c = attr[0] as System.Reflection.AssemblyCompanyAttribute;
                        _appRegistryPath = String.Format("Software\\{0}\\{1}",
                                                         p.Product, c.Company);
                    }
                    return _appRegistryPath;
                }
            }
            private Microsoft.Win32.RegistryKey _appCuKey;
            private string _rvn_Completions = "Completions";
            private readonly int _MaxMruListSize = 14;
            private System.Windows.Forms.AutoCompleteStringCollection _completions;
            private bool stateLoaded;
        }
        public static class Extensions
        {
            public static string XmlEscapeIexcl(this String s)
            {
                while (s.Contains("¡"))
                {
                    s = s.Replace("¡", "&#161;");
                }
                return s;
            }
            public static string XmlUnescapeIexcl(this String s)
            {
                while (s.Contains("&#161;"))
                {
                    s = s.Replace("&#161;", "¡");
                }
                return s;
            }
            public static List<String> ToList(this System.Windows.Forms.AutoCompleteStringCollection coll)
            {
                var list = new List<String>();
                foreach (string  item in coll)
                {
                    list.Add(item);
                }
                return list;
            }
        }
    }
