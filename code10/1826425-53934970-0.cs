       var type = Assembly.GetExecutingAssembly().GetTypes()
       .FirstOrDefault(t => t.Name == "");
                object instance = Activator.CreateInstance(type);
                foreach (var item in new Dictionary<string, string>())
                {
                    PropertyInfo information = type.GetProperties()
        .SingleOrDefault(x => x.Name == item.Key);
                    information.SetValue(instance, item.Value.ToString(), null);
                }               
              
                db.Entry(instance).State = EntityState.Modified;
                db.SaveChanges();
