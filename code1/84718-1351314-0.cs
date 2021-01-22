    public static int SaveReorder<T>(IList<int> listItems) where T : EntityObject
        {
            int result = 0;
            int volgorde = 1;
            T entityObject = null;
            using (vgplannewEntities objectContext = new vgplannewEntities())
            {
                try
                {
                    foreach (int id in listItems)
                    {
                        entityObject = objectContext.GetEntityByKey<T>(id, new String[] { });
                        PropertyInfo pi = entityObject.GetType().GetProperty("Volgorde");
                        pi.SetValue(entityObject, volgorde, null);
                        objectContext.SaveChanges();
                        volgorde += 1;
                    }
                    result = 1;
                }
                catch
                {
                    result = 0;
                }
            }
            return result;
        }
