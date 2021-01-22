    <target name="someTarget">
    	<!-- full path to setup project and project file (MSI -> vdproj) -->
    	<property name="DeploymentProjectPath" value="fullPath\proj.vdproj" />
    	<!-- full path to source project and project file (EXE -> csproj) -->
    	<property name="DependencyProject" value="fullPath\proj.csproj" />
    	<script language="C#">
        <code>
          <![CDATA[
            public static void ScriptMain(Project project)
    		{
    			//Purpose of script: load the .vdproj file, replace ProductCode and PackageCode with new guids, and ProductVersion with 1.0.SnvRevisionNo., write over .vdproj file
    			
                string setupFileName = project.Properties["DeploymentProjectPath"];
    			string productVersion = string.Format("1.0.{0}", project.Properties["svn.revision"]);
    			string setupFileContents;
    			
    			//read in the .vdproj file			
    			using (StreamReader sr = new StreamReader(setupFileName))
                {
                    setupFileContents = sr.ReadToEnd();
                }
    			
    			if (!string.IsNullOrEmpty(setupFileContents))
    			{
    				Regex expression2 = new Regex(@"(?:\""ProductCode\"" = \""8.){([\d\w-]+)}");
    				Regex expression3 = new Regex(@"(?:\""PackageCode\"" = \""8.){([\d\w-]+)}");
    				Regex expression4 = new Regex(@"(?:\""ProductVersion\"" = \""8.)(\d.\d.\d+)");
    				setupFileContents = expression2.Replace(setupFileContents,"\"ProductCode\" = \"8:{" + Guid.NewGuid().ToString().ToUpper() + "}");
    				setupFileContents = expression3.Replace(setupFileContents,"\"PackageCode\" = \"8:{" + Guid.NewGuid().ToString().ToUpper() + "}");
    				setupFileContents = expression4.Replace(setupFileContents,"\"ProductVersion\" = \"8:" + productVersion);
    
    				using (TextWriter tw = new StreamWriter(setupFileName, false))
    				{
    					tw.WriteLine(setupFileContents);
    				}
    			}
            }
           ]]>
        </code>
    	</script>
    
    	<!-- must build the dependency first (code project), before building the MSI deployment project -->
    	<exec program="Devenv.exe" commandline='"fullPath\solution.sln" /rebuild "Release" /project "${DependencyProject}" /out "fullPath\somelog.log"'/>
    	<exec program="Devenv.exe" commandline='"fullPath\solution.sln" /rebuild "Release" /project "${DeploymentProjectPath}" /out "fullPath\somelog.log"'/>
    </target>
