    var context = serviceProvider.GetService(typeof(IPluginExecutionContext)) as IPluginExecutionContext;
    Entity student = context.InputParameters["Target"] as Entity;
    
    //get the department from target
    EntityReference department = student.GetAttributeValue<EntityReference>("karam_department");
    if (department != null)
    {
    //retrieve the campus from department
    Entity deptEntity = service.Retrieve("karam_department", Department.Id, new ColumnSet("karam_campus"));
    //set the campus attribute in target itself
    student["karam_campus"] = deptEntity.GetAttributeValue<EntityReference>("karam_campus");
    }
