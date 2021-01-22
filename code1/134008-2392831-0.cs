    var bufferAdapter = AdaptersFactory.GetBufferAdapter(textBuffer);
    if (bufferAdapter != null)
    {
        var persistFileFormat = bufferAdapter as IPersistFileFormat;
        if (persistFileFormat != null)
        {
            string ppzsFilename;
            uint iii;
            persistFileFormat.GetCurFile(out ppzsFilename, out iii);
            var dte2 = (DTE2) Shell.Package.GetGlobalService(typeof (SDTE));
            ProjectItem prjItem = dte2.Solution.FindProjectItem(ppzsFilename);
            var containingProject = prjItem.ContainingProject;
            // Now use the containingProject.Items to find my file, etc, etc
        }
    }
