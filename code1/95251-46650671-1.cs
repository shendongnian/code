    private void ResolveConflicts()
            {
                using (var cultura = new ResXResourceReader(CulturaPath))
                using (var culturaCustom = new ResXResourceReader(CulturaCustomPath))
                {
                    Resources = (from cc in culturaCustom.Cast<DictionaryEntry>()
                                 where !(from c in cultura.Cast<DictionaryEntry>()
                                         select new { c.Key, c.Value })
                                 .Contains(new { cc.Key, cc.Value })
                                 select new Tuple<string, string>(
                                      cc.Key.ToString(),
                                      cc.Value.ToString())).ToList();
                }
    
                ReWriteCustomFile();
            }
    
            private void ReWriteCustomFile()
            {
                using (var writer = new ResXResourceWriter(CulturaCustomPath))
                {
                    Resources.ForEach(r => writer.AddResource(r.Item1, r.Item2));
    
                    writer.Generate();
                    writer.Close();
                }
            }
