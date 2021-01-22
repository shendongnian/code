    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ output extension=".cs" #>
    <#@ assembly name="System.Xml.dll" #>
    <#@ import namespace="System.Xml" #>
    <#@ import namespace="System.Xml.XPath" #>
    using System;
    using System.ComponentModel;
    
    
    namespace Bear.Client
    {
     /// <summary>
     /// Localized display name attribute
     /// </summary>
     public class LocalizedDisplayNameAttribute : DisplayNameAttribute
     {
      readonly string _resourceName;
    
      /// <summary>
      /// Initializes a new instance of the <see cref="LocalizedDisplayNameAttribute"/> class.
      /// </summary>
      /// <param name="resourceName">Name of the resource.</param>
      public LocalizedDisplayNameAttribute(string resourceName)
       : base()
      {
       _resourceName = resourceName;
      }
    
      /// <summary>
      /// Gets the display name for a property, event, or public void method that takes no arguments stored in this attribute.
      /// </summary>
      /// <value></value>
      /// <returns>
      /// The display name.
      /// </returns>
      public override String DisplayName
      {
       get
       {
        return Resources.ResourceManager.GetString(this._resourceName);
       }
      }
     }
    
     partial class Constants
     {
      public partial class Resources
      {
      <# 
       var reader = XmlReader.Create(Host.ResolvePath("resources.resx"));
       var document = new XPathDocument(reader);
       var navigator = document.CreateNavigator();
       var dataNav = navigator.Select("/root/data");
       foreach (XPathNavigator item in dataNav)
       {
        var name = item.GetAttribute("name", String.Empty);
      #>
       public const String <#= name#> = "<#= name#>";
      <# } #>
      }
     }
    }
