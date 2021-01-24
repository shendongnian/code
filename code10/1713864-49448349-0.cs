    <?xml version="1.0" encoding="utf-8" ?>
    <AnalyseParams>
     <TargetExecutable>c:\nunit\nunit-console.exe</TargetExecutable>
     <TargetArguments>C:\Sources\out\Debug\MyLib.dll</TargetArguments>
     <TargetWorkingDir>C:\Sources\out\Debug\</TargetWorkingDir>
     <Output>coverage.xml</Output>
     <Filters>
       <IncludeFilters>
         <FilterEntry>
            <!-- We just want to cover repository classes -->
            <ClassMask>*Repository*</ClassMask>
         </FilterEntry>
       </IncludeFilters>
       <ExcludeFilters>
         <FilterEntry>
            <!-- Do not cover Test projects -->
            <ModuleMask>*Test</ModuleMask>
         </FilterEntry>
       </ExcludeFilter>
     </Filters>
    </AnalyseParams>
