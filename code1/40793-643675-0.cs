    //Name Spaces Required
    using System.Resources;
    using System.Reflection;
     
    // Create the resource manager.
    Assembly assembly = this.GetType().Assembly;
     
    //ResFile.Strings -> <Namespace>.<ResourceFileName i.e. Strings.resx>
    resman = new ResourceManager("StringResources.Strings", assembly);
     
    // Load the value of string value for Client
    strClientName = resman.GetString("Client");
