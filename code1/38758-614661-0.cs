    protected virtual Control FindControl(string id, int pathOffset)
    {
         string str;
         this.EnsureChildControls();
    if (!this.flags[0x80])
    {
         Control namingContainer = this.NamingContainer;
    if (namingContainer != null)
    {
        return namingContainer.FindControl(id, pathOffset);
    }
