    var businessRulesDtoList = Builder<BusinessRulesDto>.CreateListOfSize(2).Build().ToList();
    businessMockObject.Protected().As<IBusinessProtectedMembers>()
        .Setup(_ => _.BusinessRules)
        .Returns(businessRulesDtoList);
        
