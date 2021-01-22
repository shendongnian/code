    using System.Resources;
    using System.Reflection;
    
    Assembly assembly = this.GetType().Assembly;
    resman = new ResourceManager("StringResources.Strings", assembly);
    btnButton.Text = resman.GetString("ButtonName");
