    var tomFilter = Builders<BsonDocument>.Filter.Eq("ProductAttributes.ProductAttributeType", "Tom");
    var matchTom = PipelineStageDefinitionBuilder.Match(tomFilter);
    var colecaoFilter = Builders<BsonDocument>.Filter.Eq("ProductAttributes.ProductAttributeType", "Coleção");
    var matchColecao = PipelineStageDefinitionBuilder.Match(colecaoFilter);
    var sortByCount = PipelineStageDefinitionBuilder.SortByCount<BsonDocument, string>("$ProductAttributes.Values");
    var pipelineTom = PipelineDefinition<BsonDocument, AggregateSortByCountResult<string>>.Create(new IPipelineStageDefinition[] { matchTom, sortByCount });
    var pipelineColecao = PipelineDefinition<BsonDocument, AggregateSortByCountResult<string>>.Create(new IPipelineStageDefinition[] { matchColecao, sortByCount });
    var facetPipelineTom = AggregateFacet.Create("Tom", pipelineTom);
    var facetPipelineColecao = AggregateFacet.Create("Colecao", pipelineColecao);
    var pipeline = _products.Aggregate()
        .Unwind(p => p.ProductAttributes)
        .Unwind(p => p["ProductAttributes.Values"])
        .Facet(facetPipelineTom, facetPipelineColecao);
    Console.WriteLine(pipeline.Single().Facets.ToJson());
