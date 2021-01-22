            string frameworkFolder = GetFrameworkFolder();
            string solutionInstallationLocation = Path.GetDirectoryName(assemblyPath);
            string solutionInstallationUrl = Path.Combine(solutionInstallationLocation, "*");
            string policyLevel;
            string parentCodeGroup;
            if (machinePolicyLevel)
            {
                policyLevel = "-m"; // Use Machine-level policy.
                parentCodeGroup = "My_Computer_Zone"; // Use My_Computer_Zone for assemblies installed on the computer.
            }
            else
            {
                policyLevel = "-u"; // Use User-level policy.
                parentCodeGroup = "All_Code";
            }
            // Add the solution code group. Grant no permission at this level.
            string arguments = policyLevel + " -q -ag " + parentCodeGroup + " -url \"" + solutionInstallationUrl + "\" Nothing -n \"" + solutionCodeGroupName + "\" -d \"" + solutionCodeGroupDescription + "\"";
            try
            {
                RunCaspolCommand(frameworkFolder, arguments);
            }
            catch (Exception ex)
            {
                string error = String.Format("Cannot create the security code group '{0}'.", solutionCodeGroupName);
                throw new Exception(error, ex);
            }
            // Add the assembly code group. Grant FullTrust permissions to the main assembly.
            try
            {
                // Use the assembly strong name as the membership condition.
                // Ensure that the assembly is strong-named to give it full trust.
                //AssemblyName assemblyName = Assembly.LoadFile(assemblyPath).GetName();
                //arguments = policyLevel + " -q -ag \"" + solutionCodeGroupName + "\" -strong -file \"" + assemblyPath + "\" \"" + assemblyName.Name + "\" \"" + assemblyName.Version.ToString(4) + "\" FullTrust -n \"" + assemblyCodeGroupName + "\" -d \"" + assemblyCodeGroupDescription + "\"";
                //RunCaspolCommand(frameworkFolder, arguments);
                //TODO- MS Hardcoded for now (better at assembly dll level use todo 1)
                arguments = policyLevel + " -q -ag \"" + solutionCodeGroupName + "\" -url \"" + solutionInstallationUrl + "\" FullTrust -n \"" + assemblyCodeGroupName + "\" -d \"" + assemblyCodeGroupDescription + "\"";
                RunCaspolCommand(frameworkFolder, arguments);
                //TODO: 1 code below will create a separate group per assembly path, also need to check if AcnUI assembly is installed in GAC.
                //AddFullTrust(frameworkFolder, assemblyPath, policyLevel, solutionCodeGroupName, assemblyCodeGroupName, assemblyCodeGroupDescription);
            }
            catch (Exception ex)
            {
                try
                {
                    // Clean the solutionCodeGroupName.
                    RemoveSecurityPolicy(machinePolicyLevel, solutionCodeGroupName);
                }
                catch {}
                string error = String.Format("Cannot create the security code group '{0}'.", assemblyCodeGroupName);
                throw new Exception(error, ex);
            }
        }
        internal static void RemoveSecurityPolicy(
            bool   machinePolicyLevel,
            string solutionCodeGroupName)
        {
            string frameworkFolder = GetFrameworkFolder();
            string policyLevel;
            if (machinePolicyLevel)
                policyLevel = "-m"; // Use Machine-level policy.
            else
                policyLevel = "-u"; // Use User-level policy.
            string arguments = policyLevel + " -q -rg \"" + solutionCodeGroupName + "\"";
            RunCaspolCommand(frameworkFolder, arguments);
        }
        private static string GetFrameworkFolder()
        {
            // Get the targeted Framework folder.
            Version version = new Version(2, 0, 50727);
            return GetRuntimeInstallationDirectory(version, true);
        }
