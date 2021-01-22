    public static Type GetTypeFromFullName(string fullClassName)
    {
        AssemblyPartCollection parts = Deployment.Current.Parts;
        foreach (var part in parts)
        {
            Uri resUri = new Uri(part.Source, UriKind.Relative);
            Stream resStream = Application.GetResourceStream(resUri).Stream;
            Assembly resAssembly = part.Load(resStream);
            Type tryType = resAssembly.GetType(fullClassName, false);
            if (tryType != null)
                return tryType;
        }
        return null;
    }
