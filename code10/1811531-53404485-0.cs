    using (var indexReader = IndexReader.Open(ramDirectory, true))
        {
            using (var searcher = new IndexSearcher(indexReader))
            {
                var analyzer = new WhitespaceAnalyzer();
                MultiFieldQueryParser _MultiMatchName = new 
                MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_30,
                    new string[] { "FullName", "Name2", "Name3" }, analyzer);
                const int hitLimits = 1000;
                _MultiMatchName.DefaultOperator = QueryParser.Operator.AND;
                var query = new BooleanQuery();
                query.Add(inputName,Occur.MUST);
            }
        }
