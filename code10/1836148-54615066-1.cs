<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.2</TargetFramework>  
    <LangVersion>7.2</LangVersion>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Selenium.WebDriver" Version="3.6.0" />
    <PackageReference Include="Selenium.WebDriver.ChromeDriver" Version="2.30.0" />
  </ItemGroup>
</Project>
and the run `dotnet publish my.csproj`, the chromedriver will be published along with your app. So a small program like:
namespace WebdriverExample
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using OpenQA.Selenium.Chrome;
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }
    }
}
just works if you do `dotnet run my.csproj`
If you have a nested project structure, `publish` should still collect all the dependencies you need.
