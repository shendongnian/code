     public virtual T FindByID<T>(T typeInstance, long id, string typeName) where T : TypeBase
        {
            Assembly asm = Assembly.GetCallingAssembly();
            var item = asm.CreateInstance(typeName);
            using (IDbConnection cn = Connection)
            {
                MethodInfo getInfo = typeof(SqlMapperExtensions).GetMethod("Get");
                MethodInfo getGeneric = getInfo.MakeGenericMethod(item.GetType());
                item = getGeneric.Invoke(cn, new object[] { cn,id,null,null });
            }
            return (T)item;
        }
