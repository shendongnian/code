    internal class ReflectionCopy
    {
        public static ToType Copy<ToType>(object from) where ToType : new()
        {
            return (ToType)Copy(typeof(ToType), from);
        }
        public static object Copy(Type totype, object from)
        {
            object to = Activator.CreateInstance(totype);
            PropertyInfo[] tpis = totype.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] fpis = from.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            // Go through each property on the "to" object
            Array.ForEach(tpis, tpi =>
            {
                // Find a matching property by name on the "from" object
                PropertyInfo fpi = Array.Find(fpis, pi => pi.Name == tpi.Name);
                if (fpi != null)
                {
                    // Do the source and destination have identical types (built-ins)?
                    if (fpi.PropertyType == tpi.PropertyType)
                    {
                        // Transfer the value
                        tpi.SetValue(to, fpi.GetValue(from, null), null);
                    }
                    else
                    {
                        // If type names are the same (ignoring namespace) copy them recursively
                        if (fpi.PropertyType.Name == tpi.PropertyType.Name)
                            tpi.SetValue(to, Copy(tpi.PropertyType, tpi.GetValue(from, null)), null);
                    }
                }
            });
            return to;
        }
    }
    
    namespace Rate
    {
        partial class WebAuthenticationDetail
        {
            public static implicit operator Ship.WebAuthenticationDetail(WebAuthenticationDetail from)
            {
                return ReflectionCopy.Copy<Ship.WebAuthenticationDetail>(from);
            }
        }
        partial class WebAuthenticationCredential
        {
            public static implicit operator Ship.WebAuthenticationCredential(WebAuthenticationCredential from)
            {
                return ReflectionCopy.Copy<Ship.WebAuthenticationCredential>(from);
            }
        }
    }
    namespace Ship
    {
        partial class WebAuthenticationDetail
        {
            public static implicit operator Rate.WebAuthenticationDetail(WebAuthenticationDetail from)
            {
                return ReflectionCopy.Copy<Rate.WebAuthenticationDetail>(from);
            }
        }
        partial class WebAuthenticationCredential
        {
            public static implicit operator Rate.WebAuthenticationCredential(WebAuthenticationCredential from)
            {
                return ReflectionCopy.Copy<Rate.WebAuthenticationCredential>(from);
            }
        }
    }
