    public static Type GetTypeFromUri(Uri uri)
    {
        Type type = null;
        using (var stream = Application.GetResourceStream(uri).Stream)
        using (var reader = new Baml2006Reader(stream))
        {
            while (reader.Read())
            {
                if (reader.Type != null)
                {
                    type = reader.Type.UnderlyingType;
                    break;
                }
            }
        }
        return type;
    }
