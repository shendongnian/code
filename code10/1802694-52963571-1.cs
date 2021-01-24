    public void Create<T>(T node) where T : class
        {        
            if (!_elasticClient.IndexExists(_indexName).Exists)
            {
                var indexSettings = new IndexSettings();
                indexSettings.NumberOfReplicas = 1;
                indexSettings.NumberOfShards = 3;
    
                var createIndexDescriptor = new CreateIndexDescriptor(_indexName)
               .Mappings(ms => ms
                               .Map<T>(m => m.AutoMap())
                        )
                .InitializeUsing(new IndexState() { Settings = indexSettings })
                .Aliases(a => a.Alias(aliasName));
    
                var response = _elasticClient.CreateIndex(createIndexDescriptor);
            }
    
            _elasticClient.Index<T>(node, idx => idx.Index(_indexName));
        }
    }	
