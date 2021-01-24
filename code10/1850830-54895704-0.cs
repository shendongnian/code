    internal class ma_DisplayNameAttribute : System.ComponentModel.DisplayNameAttribute
    {
      public ma_DisplayNameAttribute( string ResourceName )
        : base ( AttributeTest.Properties.Resources.ResourceManager.GetString(ResourceName) )
      {
      }
    }
