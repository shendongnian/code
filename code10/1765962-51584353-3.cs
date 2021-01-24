    public static void InsertNode(string node_name, float x, float y, float z_cover)
    {
        Tables tables = Application.OpenForms.OfType<Tables>().FirstOrDefault();
        if (tables != null)
            tables.UpdateNodeForm();
    }
