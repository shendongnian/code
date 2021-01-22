    public static Type GetGlobalType(string s)
            {
                Type t=null;
                Assembly[] av = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly a in av)
                {
                    t=Type.GetType(s + "," + a.GetName());
                    if (t != null)
                        break;
                }
                return t;
            }
