        <PropertyGroup>
           <TargetFramework>netcoreapp2.2</...
           ...
           <MvcRazorCompileOnPublish>true</MvcRazorCompileOnPublish>
           <PreserveCompilationContext>true</PreserveCompilationContext>
        </PropertyGroup>
        
          <ItemGroup>
            ...
            <PackageReference Include="Microsoft.AspNetCore.Mvc.Razor.ViewCompilation" Version="2.2.0" />    
          </ItemGroup>
