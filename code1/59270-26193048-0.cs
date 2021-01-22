    using System;
    using Microsoft.UpdateServices.Administration;
    using SimpleImpersonation;
     
    namespace MAJSRS_CalendarChecker
    {
        class WSUS
        {
            public WSUS()
            {
                // I use impersonation to use other logon than mine. Remove the following "using" if not needed
                using (Impersonation.LogonUser("mydomain.local", "admin_account_wsus", "Password", LogonType.Batch))
                {
                    ComputerTargetScope scope = new ComputerTargetScope();
                    IUpdateServer server = AdminProxy.GetUpdateServer("wsus_server.mydomain.local", false, 80);
                    ComputerTargetCollection targets = server.GetComputerTargets(scope);
                    // Search
                    targets = server.SearchComputerTargets("any_server_name_or_ip");
                    
                    // To get only on server FindTarget method
                    IComputerTarget target = FindTarget(targets, "any_server_name_or_ip");
                    Console.WriteLine(target.FullDomainName); 
                    IUpdateSummary summary = target.GetUpdateInstallationSummary();
                    UpdateScope _updateScope = new UpdateScope();
                    // See in UpdateInstallationStates all other properties criteria
                    _updateScope.IncludedInstallationStates = UpdateInstallationStates.Downloaded;
                    UpdateInstallationInfoCollection updatesInfo = target.GetUpdateInstallationInfoPerUpdate(_updateScope);
                   
                    int updateCount = updatesInfo.Count;
     
                    foreach (IUpdateInstallationInfo updateInfo in updatesInfo)
                    {
                        Console.WriteLine(updateInfo.GetUpdate().Title);
                    }
                }
            }
            public IComputerTarget FindTarget(ComputerTargetCollection coll, string computername)
            {
                foreach (IComputerTarget target in coll)
                {
                    if (target.FullDomainName.Contains(computername.ToLower()))
                        return target;
                }
                return null;
            }
        }
    }
     
