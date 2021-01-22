    using System.Linq;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    
    var cmdlets = Runspace.DefaultRunspace.RunspaceConfiguration.Cmdlets;
    var snapins = (from cmdlet in cmdlets
                  select new { cmdlet.PSSnapin.Name }).Distinct();
