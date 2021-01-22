        foreach (Type t in assembly.GetExportedTypes())  
        {
            Console.WriteLine(t.Name);
            
            if (t.Name.EndsWith("Composite"))
            {
                var attributes = t.GetCustomAttributes(false);
                ToolboxListItem item = new ToolboxListItem();
                CompositeMetaDataAttribute meta = (CompositeMetaDataAttribute)attributes
                           .Where(a => a.GetType() == typeof(Vialis.LightLink.Attributes.CompositeMetaDataAttribute)).First();
                item.Name = meta.DisplayName;
                item.Description = meta.Description;
                item.Length = meta.Length;
                item.CompositType = t;
                
                this.lstCommands.Items.Add(item);
            }                           
        }
