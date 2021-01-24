    public async Task<IRuleServiceOutput<bool>> ExecuteAsync(Test test)
            {
                var errors = new List<string>();
    
                object whereClause = new { ID = test.ID };
                FormattableString formattableString = $"ID = @ID";
    
                var output = (await m.Find(formattableString, whereClause)).ToArray();
               
                return new RuleServiceOutput<bool>(output.Errors.IsEmpty(), output.Errors);
            }
