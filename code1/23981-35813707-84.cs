    using Windows.UI.Xaml.Resources;
    public class MyXamlResourceLoader : CustomXamlResourceLoader
    {
        protected override object GetResource(string resourceId, string objectType, string propertyName, string propertyType)
        {
            return MyProject.Language.Resources.ResourceManager.GetString(resourceId);
        }
    }
