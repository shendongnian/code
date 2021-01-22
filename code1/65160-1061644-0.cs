    <UserControl x:Class="SomeNamespace.SomeClass"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
        <TreeView ItemsSource="{Binding XPath=/items}">
            <TreeView.Resources>
                <HierarchicalDataTemplate DataType="items" ItemsSource="{Binding XPath=*}">
                    <TextBlock Text="{Binding XPath=@Header}" />
                </HierarchicalDataTemplate>
                <HierarchicalDataTemplate DataType="item" ItemsSource="{Binding XPath=*}">
                    <TextBlock Text="{Binding XPath=@Header}" />
                </HierarchicalDataTemplate>
            </TreeView.Resources>
        </TreeView>
    </UserControl>
----------
    public partial class SomeClass : UserControl
    {
        public XmlDataProvider SomeXmlDataProvider { get; set; }
    
        public SomeClass()
        {
            InitializeComponent();
    
            this.SomeXmlDataProvider = new XmlDataProvider();
            this.SomeXmlDataProvider.Document = new XmlDocument();
            this.SomeXmlDataProvider.Document.LoadXml("<items Header=\"Some items\"><item Header=\"Some item\" /></items>");
            this.DataContext = this.SomeXmlDataProvider.Document;
        }
    }
