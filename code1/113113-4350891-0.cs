        static public Tattr GetSingleAttribute<Tattr>(this PropertyInfo pi, bool Inherit = true) where Tattr : Attribute
        {
            var attrs = pi.GetCustomAttributes(typeof(Tattr), Inherit);
            if (attrs.Length > 0)
                return (Tattr)attrs[0];
            var mt = pi.DeclaringType.GetSingleAttribute<MetadataTypeAttribute>();
            if (mt != null)
            {
                var pi2 = mt.MetadataClassType.GetProperty(pi.Name);
                if (pi2 != null)
                    return pi2.GetSingleAttribute<Tattr>(Inherit);
            }
            return null;
        }
