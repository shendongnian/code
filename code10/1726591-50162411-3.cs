    public SolrQueryResults<T> QueryWithRawXml<T>(this ISolrOperations<T> operations, 
            ISolrQuery query, QueryOptions queryOptions, out XDocument xml)
        {
            var executor = (SolrQueryExecuter<T>)ServiceLocator.Current.GetInstance<ISolrQueryExecuter<T>>();
            var connectionKey = string.Format("{0}.{1}.{2}", typeof(SolrConnection), typeof(T), typeof(SolrConnection));
            var connection = ServiceLocator.Current.GetInstance<ISolrConnection>(connectionKey);
            var parser = ServiceLocator.Current.GetInstance<ISolrAbstractResponseParser<T>>();
            var parameters = executor.GetAllParameters(query, queryOptions);
            var responseXml = connection.Get(executor.Handler, parameters);
            xml = XDocument.Parse(responseXml);
            var results = new SolrQueryResults<T>();
            parser.Parse(xml, results);
            return results;
        }
    public IEnumerable<KeyValuePair<string, int> GetJsonFacets(
        XDocument xml, string facetFieldName, string countFieldName = "count")
    {
        var response = xml.Element("response");
        if (response == null)
        {
            yield break;
        }
        var mainFacetNode = response
            .Elements("lst")
            .FirstOrDefault(e => e.Attribute("name")?.Value == "facets");
        if (mainFacetNode == null)
        {
            yield break;
        }
        var groupFacetElement = mainFacetNode
            .Elements("lst")
            .FirstOrDefault(x => x.Attribute("name")?.Value == facetFieldName);
        if (groupFacetElement == null)
        {
            yield break;
        }
        var buckets = groupFacetElement.Elements("arr")
            .FirstOrDefault(x => x.Attribute("name")?.Value == "buckets");
        if (buckets == null)
        {
            yield break;
        }
        foreach (var bucket in buckets.Elements("lst"))
        {
            var valNode = bucket.Elements()
                .FirstOrDefault(x => x.Attribute("name")?.Value == "val");
            var countNode = bucket.Elements()
                .FirstOrDefault(x => x.Attribute("name")?.Value == countFieldName);
            int count;
            if (valNode != null && countNode != null && 
                int.TryParse(countNode.Value, out count))
            {
                yield return new KeyValuePair<string, int>(valNode.Value,count)
            }
        }
    }
