    var activeInstancesRequest = new RetrieveProcessInstancesRequest
    {
    	EntityId          = TargetEntity.Id,
    	EntityLogicalName = TargetEntity.LogicalName
    };
    var activeInstancesResponse = (RetrieveProcessInstancesResponse)base.OrgService.Execute(activeInstancesRequest);
    var process = activeInstancesResponse.Processes.Entities.Select(x => x.ToEntity<BusinessProcessFlowInstance>()).ToList();
    var stages = base.XrmContext.ProcessStageSet
    	.Where(s => s.ProcessId.Id == process.FirstOrDefault().ProcessId.Id)
    	.Select(s => new ProcessStage
    	{
    		ProcessStageId = s.ProcessStageId,
    		StageName = s.StageName
    	})
    	.ToList();
    
    var targetStage = stages.Where(stage => stage.StageName == targetStageName).FirstOrDefault();
    if (targetStage != null)
    {
    	crmWorkflowContext.Trace($"BPF contains target stage (\"{targetStageName}\"). Attempting to update BPF");
    
    	// Setting the Traversed Path is necessary for the Business Process Flow to show the active Stage
    	// If this is not updated then although the new Stage is set as current, the previous Stage remains actively selected
    	var traversedPath = $"{bpf.TraversedPath},{targetStage.ProcessStageId.Value}";
    	var update = new BusinessProcessFlowInstance()
    	{
    		BusinessProcessFlowInstanceId = bpf.BusinessProcessFlowInstanceId,
    		ProcessStageId                = targetStage.ProcessStageId,
    		TraversedPath                 = traversedPath	
    	};
    
    	xrmContext.Attach(update);
    	xrmContext.UpdateObject(update);
    }
