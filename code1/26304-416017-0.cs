    public void Analyze(FileInfo file) {
            Assembly asm = Assembly.LoadFrom(file.FullName);
            List<Data.AnyPlugin> types = GetPluginTypes(asm.GetTypes());
            if (types.Count > 0) {
                types.ForEach(x => x.AssemblyPath = file.FullName);
                if (_plugins.ContainsKey(file.FullName)) {
                    _plugins[file.FullName].Plugins.AddRange(types);
                } else {
                    AssemblyPlugin asp = new AssemblyPlugin();
                    asp.Ass = asm;
                    asp.Plugins = types;
                    _plugins.Add(file.FullName, asp);
                }
            }
        }
        private List<Data.AnyPlugin> GetPluginTypes(Type[] types) {
            List<Data.AnyPlugin> returnTypes = new List<AnyPlugin>();
            foreach (Type t in types) {
                Data.AnyPlugin st = GetPluginType(t);
                if (st != null) returnTypes.Add(st);
            }
            return returnTypes;
        }
        private Data.AnyPlugin GetPluginType(Type type) {
            if (type.IsSubclassOf(typeof(Screens.bScreen<T>))) {
                Screens.ScreenInfoAttribute s = GetScreenAttrib(type);
                if (s != null) {
                    return new Data.ScreenPlugin("", type, s);
                }
            } else if (type.IsSubclassOf(typeof(Widgets.bWidget<T>))) {
                Widgets.WidgetInfoAttribute w = GetWidgetAttrib(type);
                if (w != null) return new Data.WidgetPlugin("", type, w);
            }
            return null;
        }
        private Screens.ScreenInfoAttribute GetScreenAttrib(Type t) {
            Attribute a = Attribute.GetCustomAttribute(t, typeof(Screens.ScreenInfoAttribute));
            return (Screens.ScreenInfoAttribute)a;
        }
