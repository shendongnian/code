    <Project xmlns='http://schemas.microsoft.com/developer/msbuild/2003' ToolsVersion="12.0">
      <UsingTask TaskName="SetBuildDate" TaskFactory="CodeTaskFactory" 
        AssemblyFile="$(MSBuildToolsPath)\Microsoft.Build.Tasks.v12.0.dll">
        <ParameterGroup>
          <FilePath ParameterType="System.String" Required="true" />
        </ParameterGroup>
        <Task>
          <Code Type="Fragment" Language="cs"><![CDATA[
			DateTime now = DateTime.UtcNow;
			string buildDate = now.ToString("F");
			string replacement = string.Format("BuildDate => \"{0}\"", buildDate);
			string pattern = @"BuildDate => ""([^""]*)""";
			string content = File.ReadAllText(FilePath);
			System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex(pattern);
			content = rgx.Replace(content, replacement);
			File.WriteAllText(FilePath, content);
			File.SetLastWriteTimeUtc(FilePath, now);
    
       ]]></Code>
        </Task>
      </UsingTask>
	
    </Project>
