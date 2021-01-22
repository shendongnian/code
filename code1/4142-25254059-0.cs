        namespace Xceed.Wpf.Toolkit.PropertyGrid
        {
            public interface IPropertyDescription
            {
                double MinimumFor(string propertyName);
                double MaximumFor(string propertyName);
                double IncrementFor(string propertyName);
                int DisplayOrderFor(string propertyName);
                string DisplayNameFor(string propertyName);
                string DescriptionFor(string propertyName);
                bool IsReadOnlyFor(string propertyName);
            }
        }
    
