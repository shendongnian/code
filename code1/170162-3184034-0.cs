    List<Entries> result = new List<Entries>();
    GetEventLogs().Where(x => x.LogDisplayName.Equals("AAA")).ToList().ForEach(delegate(Log en)
            {
                en.Entries.Where(y => y.Source.Equals("BBB", StringComparison.InvariantCultureIgnoreCase)).ToList().ForEach(delegate(Entries ent)
                {
                    result.Add(ent);
                });
            });
