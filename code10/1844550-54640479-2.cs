    var test = new Test {ID = 5};
    object whereClause = new { ID = test.ID };
                FormattableString formattableString = $"ID = @ID";
    
                m.Setup(x => x.Find(formattableString, whereClause)).ReturnsAsync(new List<Foo>());
    
     var ruleServiceOutput = await this.testValidationRuleService.ExecuteAsync(test);
