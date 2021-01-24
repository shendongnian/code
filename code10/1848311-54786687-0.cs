    public List<SchemaValidationResults> GetChildLessError(SchemaValidationResults errors)
    {
        List<SchemaValidationResults> childLessErrors = new List<SchemaValidationResults>();
        if(errors.NestedResults.Any())
        {
            foreach(var resultChild in errors.NestedResults)
            {
                childLessErrors.AddRange(GetChildLessError(resultChild));
            }
        }
        else
        {
            childLessErrors.Add(errors);                    
        }
        return childLessErrors;
    }
