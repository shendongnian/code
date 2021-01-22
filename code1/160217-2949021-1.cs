                VBProject project = workbook.VBProject;
            for (int i = project.VBComponents.Count; i >= 1; i--)
            {
                VBComponent component = project.VBComponents.Item(i);
                try
                {
                    project.VBComponents.Remove(component);
                }
                catch(ArgumentException)
                {
                    continue;
                }
            }
            for (int i = project.VBComponents.Count; i >= 1; i--)
            {
                VBComponent component = project.VBComponents.Item(i);
                    component.CodeModule.DeleteLines(1, component.CodeModule.CountOfLines);
            }
