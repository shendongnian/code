    <Project DefaultTargets="Build">
      <UsingTask TaskName="HelloWorld" TaskFactory="RoslynCodeTaskFactory" AssemblyFile="$(MSBuildToolsPath)\Microsoft.Build.Tasks.Core.dll">
        <Task>
          <Code Type="Fragment" Language="cs">
            <![CDATA[Console.WriteLine($"Hello {0+1}");]]>
          </Code>
        </Task>
      </UsingTask>
    
      <Target Name="Build">
        <HelloWorld />
      </Target>
    </Project>
