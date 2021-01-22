       public static TEntity GetJsonModel<TEntity>(TEntity Entity) where TEntity : class
        {
            TEntity Entity_ = Activator.CreateInstance(typeof(TEntity)) as TEntity;
            foreach (var item in Entity.GetType().GetProperties())
            {
                if (item.PropertyType.ToString().IndexOf("Generic.ICollection") == -1 && item.PropertyType.ToString().IndexOf("SaymenCore.DAL.") == -1)
                    item.SetValue(Entity_, Entity.GetPropValue(item.Name));
            }
            return Entity_;  
        }
