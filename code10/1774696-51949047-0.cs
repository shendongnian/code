        private static void AddXmlFileToProject(string tempPath)
        {
            try
            {
                var project = GetProject();
                foreach (EnvDTE.ProjectItem projectItem in project.ProjectItems)
                {
                    if (projectItem.Name == "Properties")
                    {
                        foreach (EnvDTE.ProjectItem item in projectItem.ProjectItems)
                        {
                            if (item.Name == FileName)
                            {
                                EditExistingFile(item);
                                return;
                            }
                        }
                        projectItem.ProjectItems.AddFromFileCopy(tempPath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static void EditExistingFile(EnvDTE.ProjectItem projectItem)
        {
            try
            {
                projectItem.Open();
                var textSelection = (TextSelection)projectItem.Document.Selection;
                projectItem.Document.ReadOnly = false;
                textSelection.SelectAll();
                textSelection.Text = new XML Content here
                projectItem.Document.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
