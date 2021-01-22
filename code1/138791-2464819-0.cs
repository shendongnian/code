    /// </summary>
    /// Event triggered when a search is entered in any <see cref="SearchPanel"/>
    /// </summary>
    public event EventHandler<string> SearchEntered
    {
        add { searchevent += value; }
        remove { searchevent -= value; }
    }
    private event EventHandler<string> searchevent;
