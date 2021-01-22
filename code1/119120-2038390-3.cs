    static class ProxyInstantiator
    {
        public static TProxy CreateProxy<TProxy>(object source)
            where TProxy : new()
        {
            TProxy proxy = new TProxy();
            CopyProperties(source, proxy);
            return proxy;
        }
        protected static void CopyProperties(object source, object dest)
        {
            if (dest == null)
            {
                throw new ArgumentNullException("dest");
            }
            if (source == null)
            {
                return;
            }
            Type sourceType = source.GetType();
            PropertyInfo[] sourceProperties =
                sourceType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            Type destType = dest.GetType();
            PropertyInfo[] destProperties =
                destType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var propsToCopy =
                from sp in sourceProperties
                join dp in destProperties on sp.Name equals dp.Name
                select new { SourceProperty = sp, DestProperty = dp };
            foreach (var p in propsToCopy)
            {
                object sourceValue = p.SourceProperty.GetValue(o, null);
                p.DestProperty.SetValue(dest, sourceValue, null);
            }
        }
    }
