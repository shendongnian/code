    private Type[] types;
    private Type itemType;
    
    public CustomCollectionEditor(Type type) {
       itemType = t.GetProperty("Item").PropertyType;
       types = GetTypes();
    }
    
    private Type[] GetTypes() {
                List<Type> tList = new List<Type>();
                Assembly[] appAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly a in appAssemblies) {
                    Module[] mod = a.GetModules();
                    foreach (Module m in mod) {
                        Type[] types = m.GetTypes();
                        foreach (Type t in types) {
                            try {
                                if (/*t.Namespace == "Mynamespace.tofilter" && */!t.IsAbstract) {
                                    /* Here you should find a better way to cover all Basetypes in the inheritance tree */
                                    if (t.BaseType == itemType || t.BaseType.BaseType == itemType) { 
                                        tList.Add(t);
                                    }
                                }
                            }
                            catch (NullReferenceException) { }
                        }
                    }
                }
                return tList.ToArray();
            }
    
    
      protected override Type[] CreateNewItemTypes()
      {
        return types;
      }
