    [AttributeUsage(AttributeTargets.Class)]
    public class EnforceConforms : Attribute
    {
        public EnforceConforms(Type myClass)
            : base()
        {
            MethodInfo[] info = myClass.GetMethods();
            foreach (MethodInfo method in info)
            {
                object[] objs = method.GetCustomAttributes(false);
                foreach (object o in objs)
                {
                    Attribute t = (Attribute)o;
                    if (t.GetType() != typeof(ConformsAttribute)) continue;
                    MethodInfo mustConformTo = ((ConformsAttribute)t).ConformTo;
                    ParameterInfo[] info1 = mustConformTo.GetParameters();
                    ParameterInfo[] info2 = method.GetParameters();
                    bool doesNotCoform = false;
                    doesNotCoform |= (mustConformTo.ReturnType != method.ReturnType);
                    doesNotCoform |= (info1.Length != info2.Length);
                    if (!doesNotCoform)
                    {
                        for (int i = 0; i < info1.Length; i++)
                        {
                            ParameterInfo p1 = info1[i];
                            ParameterInfo p2 = info2[i];
                            if (!p1.ParameterType.Equals(p2.ParameterType))
                            {
                                doesNotCoform = true;
                                break;
                            }
                        }
                    }
                    if (doesNotCoform)
                    {
                        throw new Exception(myClass.Name + "." + method.Name + " does not conform to required delegate signature");
                    }
                }
            }
        }
    }
    [AttributeUsage(AttributeTargets.Method)]
    public class ConformsAttribute : Attribute
    {
        public MethodInfo ConformTo;
        public ConformsAttribute(Type type)
            : base()
        {
            if (type.BaseType != typeof(Delegate) && type.BaseType != typeof(System.MulticastDelegate)) throw new Exception("Can only accept delegates");
            ConformTo = type.GetMethod("Invoke");
        }
    }
