    using System;
    using Microsoft.BizTalk.ExplorerOM;
    public static void EnumerateOrchestrationArtifacts()
    {
        // Connect to the local BizTalk Management database
        BtsCatalogExplorer catalog = new BtsCatalogExplorer();
        catalog.ConnectionString = "Server=.;Initial Catalog=BizTalkMgmtDb;Integrated Security=SSPI;";
    
        // Enumerate all orchestrations and their ports/roles
        Console.WriteLine("ORCHESTRATIONS: ");
        foreach(BtsAssembly assembly in catalog.Assemblies)
        {
            foreach(BtsOrchestration orch in assembly.Orchestrations)
            {
    
                Console.WriteLine(" Name:{0}\r\n Host:{1}\r\n Status:{2}",
                    orch.FullName, orch.Host.Name, orch.Status);
    
                // Enumerate ports and operations
                foreach(OrchestrationPort port in orch.Ports)
                {
                    Console.WriteLine("\t{0} ({1})", 
                        port.Name, port.PortType.FullName);
    
                    foreach(PortTypeOperation operation in port.PortType.Operations)
                    {
                        Console.WriteLine("\t\t" + operation.Name);
                    }
                }
    
                // Enumerate used roles
                foreach(Role role in orch.UsedRoles)
                {
                    Console.WriteLine("\t{0} ({1})", 
                        role.Name, role.ServiceLinkType);
    
                    foreach(EnlistedParty enlistedparty in role.EnlistedParties)
                    {
                        Console.WriteLine("\t\t" + enlistedparty.Party.Name);
                    }
                }
    
                // Enumerate implemented roles
                foreach(Role role in orch.ImplementedRoles)
                {
                    Console.WriteLine("\t{0} ({1})", 
                        role.Name, role.ServiceLinkType);
                }
            }
        }
    }
