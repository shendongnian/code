    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Security.Policy;
    using System.Security;
    using Outlook2003KnowledgeBaseAddIn.Setup;
    using Outlook2003KnowledgeBaseAddIn.UI;
    using Outlook2003KnowledgeBaseAddIn.UI.OutlookIntegration;
    
    namespace Outlook2003KnowledgeBaseAddIn
    {
        [System.ComponentModel.RunInstaller(true)]
        public class Installer : System.Configuration.Install.Installer
        {
            public Installer()
            {
            }
    
            public override void Install(System.Collections.IDictionary stateSaver)
            {
                base.Install(stateSaver);
    
                try
                {
                    ConfigureSecurityPolicy();
                    RegisterFolderHomePages();
                }
                catch (Exception ex)
                {
                    throw new System.Configuration.Install.InstallException("Custom Installer Failed", ex);
                }
            }
    
            public override void Uninstall(System.Collections.IDictionary savedState)
            {
                base.Uninstall(savedState);
    
                try
                {
                    DeleteSecurityPolicy();
                    UnregisterFolderHomePages();
                }
                catch (Exception ex)
                {
                    throw new System.Configuration.Install.InstallException("Custom Installer Failed", ex);
                }
            }
    
            private void RegisterFolderHomePages()
            {
                //Utility.FolderHomePage.RegisterSafeForScripting(typeof(FolderHomePages.AccountToday));
                FolderHomePage.RegisterSafeForScripting(typeof(WebViewControl));
            }
    
            private void UnregisterFolderHomePages()
            {
                //Utility.FolderHomePage.UnregisterSafeForScripting(typeof(FolderHomePages.AccountToday));
                FolderHomePage.UnregisterSafeForScripting(typeof(WebViewControl));
            }
    
            private void ConfigureSecurityPolicy()
            {
                // Find the machine policy level
                PolicyLevel machinePolicyLevel = GetMachinePolicyLevel();
    
                // Get the install directory of the current installer
                string assemblyPath = this.Context.Parameters["assemblypath"];
                string installDirectory =
                    assemblyPath.Substring(0, assemblyPath.LastIndexOf("\\"));
    
                if (!installDirectory.EndsWith(@"\"))
                    installDirectory += @"\";
    
                installDirectory += "*";
    
                // Create the code group
                CodeGroup codeGroup = new UnionCodeGroup(
                    new UrlMembershipCondition(installDirectory),
                    new PolicyStatement(new NamedPermissionSet("FullTrust")));
                codeGroup.Description = Properties.Resources.CasPolicyDescription;
                codeGroup.Name = Properties.Resources.CasPolicyName;
    
                // Add the code group
                machinePolicyLevel.RootCodeGroup.AddChild(codeGroup);
    
                // Save changes
                SecurityManager.SavePolicy();
            }
    
            private static void DeleteSecurityPolicy()
            {
                PolicyLevel machinePolicy = GetMachinePolicyLevel();
    
                foreach (CodeGroup codeGroup in machinePolicy.RootCodeGroup.Children)
                {
                    if (codeGroup.Name == Properties.Resources.CasPolicyName)
                        machinePolicy.RootCodeGroup.RemoveChild(codeGroup);
                }
    
                SecurityManager.SavePolicy();
            }
    
            private static PolicyLevel GetMachinePolicyLevel()
            {
                System.Collections.IEnumerator policyHierarchy = SecurityManager.PolicyHierarchy();
    
                while (policyHierarchy.MoveNext())
                {
                    PolicyLevel level = (PolicyLevel)policyHierarchy.Current;
                    if (level.Type == PolicyLevelType.Machine)
                        return level;
                }
    
                throw new ApplicationException("Could not find Machine Policy level. Code Access Security is not configured for this application.");
            }
        }
    }
