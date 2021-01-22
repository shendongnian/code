    public string[] GetTransistions(string strUser)
    {
        string[] strRoles = System.Web.Security.Roles.GetRolesForUser(strUser);
        List<string> strActivity = new List<string>();
        ReadOnlyCollection<WorkflowQueueInfo> queues = workflowInstance.GetWorkflowQueueData();
        foreach (WorkflowQueueInfo info in queues)
        {
            if (!info.QueueName.Equals("SetStateQueue"))
            {
                foreach (string subscribedActivity in info.SubscribedActivityNames)
                {
                    HandleExternalEventActivity heea = workflowInstance.GetWorkflowDefinition().GetActivityByName(subscribedActivity) as HandleExternalEventActivity;
                    #region check roles
                    if (heea.Roles != null)
                    {
                        foreach (WorkflowRole workflowRole in heea.Roles)
                        {
                            foreach (string strRole in strRoles)
                            {
                                if (workflowRole.Name.Equals(strRole))
                                {
                                    strActivity.Add(heea.EventName);
                                    //permissionLog += workflowRole.Name + " can perform " + heea.EventName + " Activity. ";
                                }
                            }
                        }
                    }
                    #endregion
                }
            }
        }
        return strActivity.ToArray();
    }
