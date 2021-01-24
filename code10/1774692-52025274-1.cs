    public class CustomSection : ConfigurationSectionBase
    {
        [ConfigurationProperty("name")]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }
        [ConfigurationProperty("child")]
        public ChildElement Child => base.GetElement<ChildElement>("child");
    }
    public class ChildElement : ConfigurationElementBase
    {
        [ConfigurationProperty("name")]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }
        [ConfigurationProperty("nestedchild")]
        public NestedChildElement NestedChild => base.GetElement<NestedChildElement>("nestedchild");
    }
    public class NestedChildElement : ConfigurationElement
    {
        [ConfigurationProperty("name")]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }
        public void Sample()
        {
            ChildElement parentChildElement = this.GetParent<ChildElement>();
            CustomSection parentCustomSection = parentChildElement.GetParent<CustomSection>();
            // TODO Use the parents ...
        }
