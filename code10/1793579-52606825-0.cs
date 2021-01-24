        private object ConvertRelations(object origin, object to)
        {
            List<PropertyInfo> relationProperties = new List<PropertyInfo>();
            PropertyInfo[] cRels = to.GetType().GetProperties();
            foreach (var property in origin.GetType().GetProperties())
            {
                if (property.Name.EndsWith("Relatie") || property.Name.EndsWith("Rel") || property.Name.EndsWith("Relaties"))
                {
                    // initial check for class to filter out the auto-generated integer properties
                    if(property.PropertyType.IsClass)
                        relationProperties.Add(property);
                }
            }
            // to prevent unnecessary work
            if(relationProperties.Count == 0)
            {
                return null;
            }
            foreach (var relProp in relationProperties)
            {
                var parent = relProp.GetValue(origin, null);
                var parentProps = parent.GetType().GetProperties();
                object match;
                // removed matchProps because the were not needed anymore
                // loop through cRels because of the database redesign
                foreach(var rel in cRels)
                {
                    // This code has been changed because the relation property wasn't an EntitySet anymore.
                    if (rel.PropertyType.IsClass)
                    {
                        // get the link through LINQ instead
                        var link = parentProps.SingleOrDefault(pr => pr.Name == rel.Name);
                        if (link != null)
                        {
                            // this speaks mostly for itself
                            // the simplifyresult is used to convert the match to the DTO model to match the property, which is a DTO
                            match = link.GetValue(parent, null);
                            rel.SetValue(to, SimplifyResult(match, Assembly.GetExecutingAssembly().CreateInstance("TicketSystemDb.DTO."+rel.PropertyType.Name)), null);
                        }
                    }
                }
            }
            return to;
        }
