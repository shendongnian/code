    private int _checkedIndex;
    
    // Zero-based
    [Bindable(true)]
    public int CheckedIndex
    {
        get { return _checkedIndex; }
        set
        {
            _checkedIndex = value;
            _items[value].Checked = true;
        }
    }
    public event EventHandler CheckedIndexChanged;
    ToolStripMenuItem[] _items;
    private delegate void ItemHandler(ToolStripMenuItem item);
    public RadioItemCoupler(ToolStripMenuItem[] items)
    {
        _items = items;
        foreach (ToolStripMenuItem tsmi in _items)
        {
            tsmi.CheckOnClick = true;
            tsmi.CheckedChanged += new EventHandler(tsmi_CheckedChanged);
        }
    }
    void tsmi_CheckedChanged(object sender, EventArgs e)
    {
        ToolStripMenuItem that = sender as ToolStripMenuItem;
        // Restore check if checked out
        bool nothingChecked = true;
        foreach(var item in _items)
            nothingChecked = nothingChecked && !item.Checked;
        if (nothingChecked)
        {
            _items[_checkedIndex].Checked = true;
            return;
        }
        if (!that.Checked) 
            return;
        for (int i = 0; i < _items.Length; i++)
        {
            if (that != _items[i])
            {
                if (_items[i].Checked)
                    _items[i].Checked = false;
            }
            else
            {
                _checkedIndex = i;
                if (CheckedIndexChanged != null)
                    CheckedIndexChanged(this, EventArgs.Empty);
            }
        }
    }
}
