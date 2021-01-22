    private void OnMenuSourceFileOpening(object sender, ...)
    {   // open a context menu with the associated files + ".txt" files
		if (File.Exists(this.SelectedFileName))
        {
            string fileExt = Path.GetExtension(this.SelectedFileNames);
            string[] allowedExtensions = new string[] { fileExt, ".txt" };
            var fileAssociations = allowedExtensions
                .Select(ext => new FileAssociationInfo(ext));
            var progInfos = fileAssociations
                .Select(fileAssoc => new ProgramAssociationInfo (fileAssoc.ProgID));
            var toolstripItems = myProgInfos
                .Select(proginfo => new ToolStripLabel (proginfo.Description) { Tag = proginfo });
            // add also the prog info as Tag, for easy access
            //  when the toolstrip item is selected
            // of course this can also be done in one long linq statement
            // fill the context menu:
            this.contextMenu1.Items.Clear();
            this.contextMenuOpenSourceFile.Items.AddRange (toolstripItems.ToArray());
        }
    }
