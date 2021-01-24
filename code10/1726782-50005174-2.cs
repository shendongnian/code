    var roota = new ProjectCustomerA
    {
        BaseProperty = "base property value",
        CustomerProperty = "shared property value",
        ProjectCustomerAProperty = "project A value",
    };
    var xmla = roota.SaveToXmlAsType(Project.RootElementName, Project.RootElementNamespaceURI);
    var rootb = xmla.LoadFromXmlAsType<ProjectCustomerB>();
    var xmlb = rootb.SaveToXmlAsType(Project.RootElementName, Project.RootElementNamespaceURI);
    // Assert that the shared BaseProperty was deserialized successfully.
    Assert.IsTrue(roota.BaseProperty == rootb.BaseProperty);
    // Assert that the same-named CustomerProperty was ported over properly.
    Assert.IsTrue(roota.CustomerProperty == rootb.CustomerProperty);
