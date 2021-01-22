    public interface IPropertyContainer
    {
        void AddProperty(Property property);
        string FindPropertyValue(string name);
        Property FindProperty(string name);
        void SetPropertyValue(string name, string value);
    }
