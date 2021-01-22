        do
        {
            using (DataContext = new Models.Contexts.DatabaseDataContext())
            {
                tags = null;
                if (membership == null)
                    membership = new string[] { "Guests" };
    
                tags = DataContext.Tags.Where(t => t.Keys.Any(k => k.Ring.Name == category))
                    .Where(t => t.Keys.Any(k => k.Ring.Keys.Any(c => membership.Contains(c.Tag.Name)))).OrderBy(o => o.Name);
            }
        }
