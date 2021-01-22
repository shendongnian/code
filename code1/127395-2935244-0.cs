    foreach (Type intf in interfaces)
        {
            var tmp = intf;
            Type t = ts.Where(x => x.GetInterface(tmp.Name) != null).FirstOrDefault();
            if (t != null)
            {
                Bind(intf).To(t).InSingletonScope();
            }
        }
