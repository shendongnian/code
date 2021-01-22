    <code>[System.Xml.Serialization.XmlSerializerAssemblyAttribute(AssemblyName = "VimService.XmlSerializers")]</code>
    You should end up with something like this:
    <code>// ... Some code here ...
    [System.Xml.Serialization.XmlSerializerAssemblyAttribute(AssemblyName = "VimService.XmlSerializers")]
    public partial class VimService : System.Web.Services.Protocols.SoapHttpClientProtocol {
    // ... More code here</code>
