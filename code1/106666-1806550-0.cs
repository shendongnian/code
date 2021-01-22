    using EnvDTE;
        var host = this.Container as IDesignerHost;
        var dte = host.GetService(typeof(DTE)) as DTE;
        var activeDoc = dte.ActiveDocument;
        var project = activeDoc.ProjectItem.Collection.Parent as Project;
        project.ProjectItems.AddFromFile("\\Test.cs");
