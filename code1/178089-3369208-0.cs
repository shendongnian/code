	var el = new XElement(
		"Activity",
		new XAttribute(XName.Get("Class", "SomeNamespace"), "WorkflowConsoleApplication1.Activity1"),
		new XAttribute(
			XName.Get("VisualBasic.Settings", "SomeOtherNamespace"),
			"Assembly references and imported namespaces for internal implementation"));
	Console.WriteLine(el.ToString());
