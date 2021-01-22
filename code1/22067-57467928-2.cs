<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <DocumentationFile>Documentation.xml</DocumentationFile>
  </PropertyGroup>
</Project>
You might have an interface:
C#
using System;
namespace YourNamespace
{
    /// <summary>
    /// Represents interface for a type.
    /// </summary>
    public interface IType
    {
        /// <summary>
        /// Executes an action in read access mode.
        /// </summary>
        void ExecuteAction();
    }
}
And something that inherits from it:
using System;
namespace YourNamespace
{
    /// <summary>
    /// A type inherited from <see cref="IType"/> interface.
    /// </summary>
    public class InheritedType : IType
    {
        /// <include file='bin\Release\netstandard2.0\Documentation.xml' path='doc/members/member[@name="M:YourNamespace.IType.ExecuteAction()"]/*'/>
        public void ExecuteAction() => Console.WriteLine("Action is executed.");
    }
}
Ok, it is a bit scary, but it does add the expected elements to the `Documentation.xml`.
If you build `Debug` configuration, you can swap `Release` for `Debug` in the `file` attribute of `include` tag.
To find a correct `member`'s `name` to reference just open generated `Documentation.xml` file.
You can also try `file='Documentation.xml'`, but it fails for me.
I also assume that this approach requires a project or solution to be build at least twice (first time to create an initial XML file, and the second time to copy elements from it to itself).
The bright side is that Visual Studio validates copied elements, so it is much easier to keep documentation and code in sync with interface/base class, etc (for example names of arguments, names of type parameters, etc).
