    PipelineStageDefinition<Model, ModelResult> addFields = new BsonDocument() {
                { "$addFields", new BsonDocument() {
                        { nameof(ModelResult.IsParent), new BsonDocument() {
                            { "$eq", new BsonArray() { "$" + nameof(Model.ParentId), someParentId } }
                        }
                    }
                }
            }
        };
    var result = Col.Aggregate()
                    .Match(expression)                           
                    .AppendStage(addFields)
                    .SortByDescending(x => x.IsParent)
                    .ToList();
