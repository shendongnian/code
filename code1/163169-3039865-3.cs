      private Project GetProject()
        {
            if (_applicationObject.Solution == null || _applicationObject.Solution.Projects == null || _applicationObject.Solution.Projects.Count < 1)
                return null;
            if (_applicationObject.SelectedItems.Count == 1 && _applicationObject.SelectedItems.Item(1).Project != null)
                return _applicationObject.SelectedItems.Item(1).Project;
            return null;
        }
