    int activeCount = 0;
    int completedCount = 0;
    int proposalCount = 0;
    int proposalRejCount = 0;
    foreach (var item in lst) {
        if (item.StatusID == (int)ProjectStatus.Project_Active) 
            activeCount++;
        else if (item.StatusID == (int)ProjectStatus.Project_Completed) 
            completedCount++;
        else if (item.StatusID == (int)ProjectStatus.Project_UnderProcess) 
            proposalCount++;
        else if (item.StatusID == (int)ProjectStatus.Project_Proposal_Rejected) 
            proposalRejCount++;
    }
    lblActive.InnerText = activeCount.ToString();
    lblCompleted.InnerText = completedCount.ToString();
    lblProposal.InnerText = proposalCount.ToString();
    lblProposalRej.InnerText = proposalRejCount.ToString();
