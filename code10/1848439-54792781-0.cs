    if (OOBNo == split && SiteNo.Contains(OOBName))
    {
        sitedata.CabinOOB = oobdata.CabinOOB;
        sitedata.TowerOOB = oobdata.TowerOOB;
        sitedata.ManagedOOB = oobdata.ManageOOB;
        sitedata.IssueDescription = oobdata.Description;
        sitedata.TargetResolutionDate = oobdata.TargetResolutionDate;
    
        Debug.Write("Updated Site ID/Name Record: " + sitedata.Id + "/" + sitedata.SiteName);    
    }
