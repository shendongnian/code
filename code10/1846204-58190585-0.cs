    <Project Sdk="Microsoft.NET.Sdk">
      <PropertyGroup>
        <TargetFramework>netstandard2.0</TargetFramework>
        <LangVersion>8.0</LangVersion>    
        <Nullable>enable</Nullable>
      </PropertyGroup>
      <ItemGroup>
        <PackageReference Include="Microsoft.Net.Compilers" Version="3.3.1">
          <PrivateAssets>all</PrivateAssets>
          <IncludeAssets>runtime; build; native; contentfiles; analyzers</IncludeAssets>
        </PackageReference>
      </ItemGroup>
    </Project>
-
    using System;
    
    namespace CSharp8Test
    {
        public class Class1
        {
            public string? NullableString { get; } = "Test";
            
            public static void Test()
            {
                Console.WriteLine(Test2());
    	        static int Test2() => 5;
            }
        }
    }
