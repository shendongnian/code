    public event EventHandler<ProjectSelectedEventArgs> ProjectSelected;
        protected void uxProjectList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProjectSelected != null)
            {
                var keys = uxProjectList.DataKeys[uxProjectList.SelectedIndex].Values;
                var projectId = (Guid)keys[0];
                
                var args = new ProjectSelectedEventArgs(projectId);
                ProjectSelected(this, args);
            }
        }
  
