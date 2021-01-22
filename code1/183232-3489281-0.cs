            Assembly u = Assembly.LoadFile(path);
            Type t = u.GetType(class title);
            if (t != null)
            {
                MethodInfo m = t.GetMethod(method);
                if (m != null)
                {
                    if (parameters.Length >= 1)
                    {
                        object[] myparam = new object[1];
                        myparam[0] = ......;
                        return (string)m.Invoke(null, myparam);
                    }
                    else
                    {
                        return (string)m.Invoke(null, null);
                    }
                }
            }
            else
            {
                 // throw exception. type not found
            }
