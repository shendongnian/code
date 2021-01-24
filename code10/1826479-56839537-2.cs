    public class FormAuditActionFilter : IActionFilter
    {
        private ILog _log { get; set; }
        private IFormAuditor _auditor { get; set; }
    
        public FormAuditActionFilter(ILog log, IFormAuditor auditor)
        {
            _log = log;
            _auditor = auditor;
        }
        ...lots of filter code...
        ... The following is from OnActionExecuted, having stored the props of the submitted object in objectProperties...
        
        foreach(PropertyInfo propertyInfo in objectProperties)
        {
            // Check first for any special audit comparison rules which should be followed
            var auditRuleAttributes = propertyInfo.CustomAttributes
            	.Where(x => x.AttributeType.Name == typeof(AuditRulesetAttribute).Name)
            	.ToList();
            
            if (auditRuleAttributes.Any())
            {
            	IEnumerable<IList<CustomAttributeTypedArgument>> attrList = auditRuleAttributes
            		.Select(x => x.ConstructorArguments);
            	
            	foreach(IList<CustomAttributeTypedArgument> attr in attrList)
            		foreach(CustomAttributeTypedArgument arg in attr)
            			if (_auditRuleManager.IsChanged(oldValue, newValue, (AuditRule)arg.Value))
            				result.Add(BuildValueHistory(propertyInfo.Name, oldValue, newValue));
            	continue;
            }
        }
        ...lots more filter code...
    }
