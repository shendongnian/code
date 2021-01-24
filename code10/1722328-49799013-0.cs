    public static void PrintFileMeta(string path)
    {
        using (ClientContext context = GetContext())
        {
            File file = context.Web.GetFileByServerRelativeUrl(path);
    
            var item = file.ListItemAllFields;
            var fields = item.ParentList.Fields;
    
            context.Load(file, f => f.ListItemAllFields);
            context.Load(fields, include => include.Include(f => f.Id, f => f.InternalName, f => f.Title));
            context.ExecuteQuery();
    
    
    
            foreach (string fieldName in item.FieldValues.Keys)
            {
                Field field = fields.Where(f => f.InternalName == fieldName).First();
    
                Console.Write(field.Title + ": ");
                Console.WriteLine(item.FieldValues[fieldName]);
            }
    
        }
    }
