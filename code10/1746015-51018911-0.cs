    const string conditionName = "System.ExpressionFilter";
    const string dataSourceName = "Microsoft.SystemCenter.SdkPerformanceDataProvider";
    const string writeActionName = "Microsoft.SystemCenter.DataWarehouse.PublishPerformanceData";
    var managementClass = GetManagementPackClass(managementGroup, ManagementPackClass);
    
    var criteria = new ManagementPackModuleTypeCriteria($"Name = '{conditionName}' OR Name = '{dataSourceName}' OR Name = '{writeActionName}'");
    var moduleTypes = managementGroup.Monitoring.GetModuleTypes(criteria).ToList();
    
    var conditionType = moduleTypes.Single(n => n.Name == conditionName);
    var dataSourceType = moduleTypes.Single(n => n.Name == dataSourceName);
    var writeActionType = moduleTypes.Single(n => n.Name == writeActionName);
    
    foreach (var ruleName in missingRuleNames)
    {
    	var counterName = ruleName.Replace(MonitoringRulePrefix, string.Empty);
    
    	var rule = new ManagementPackRule(managementPack, ruleName)
    	{
    		Target = managementClass,
    		Category = ManagementPackCategoryType.PerformanceCollection,
    		Enabled = ManagementPackMonitoringLevel.@true,
    		ConfirmDelivery = false
    	};
    
    	rule.ConditionDetection = new ManagementPackConditionDetectionModule(rule, "ConditionDetection")
    	{
    		TypeID = (ManagementPackConditionDetectionModuleType) conditionType,
    		Configuration = $@"
    			<Expression>
    				<SimpleExpression>
    					<ValueExpression>
    						<XPathQuery>CounterName</XPathQuery>
    					</ValueExpression>
    					<Operator>Equal</Operator>
    					<ValueExpression>
    						<Value>{counterName}</Value>
    					</ValueExpression>
    				</SimpleExpression>
    			</Expression>"
    	};
    
    	var dataSource = new ManagementPackDataSourceModule(rule, "DataSource")
    	{
    		TypeID = (ManagementPackDataSourceModuleType) dataSourceType
    	};
    	rule.DataSourceCollection.Add(dataSource);
    
    	var action = new ManagementPackWriteActionModule(rule, "WriteToDataWarehouse")
    	{
    		TypeID = (ManagementPackWriteActionModuleType) writeActionType
    	};
    	rule.WriteActionCollection.Add(action);
    }
    
    managementPack.Verify();
    managementPack.AcceptChanges();
