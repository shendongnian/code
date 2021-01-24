    public static void CopyTo<T>(this object self, T to)
    {
        if (self != null)
        {
            foreach (var pi in to.GetType()
    		.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public))
            {
                pi.SetValue(to, self.GetType().GetProperty(pi.Name)?.GetValue(self, null) ?? null, null);
            }
        }
    }   
