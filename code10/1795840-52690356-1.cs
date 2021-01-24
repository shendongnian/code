    private CheckBox[] _checkBoxes;
    private bool _changing;
    public MyForm()
    {
        InitializeComponent();
        _checkBoxes = new CheckBox[] {
            checkLukitse1, checkLukitse2, checkLukitse3, checkLukitse4
        };
    }
    // All check boxes attached to this event
    private void checkLukitse_CheckedChanged(object sender, EventArgs e)
    {
        var current = (CheckBox)sender;
        if (current.Checked && !_changing) {
            _changing = true;
            try {
                foreach (CheckBox other in _checkBoxes.Where(cb => cb != current)) {
                    other.Checked = false;
                }
            } finally {
                _changing = false;
            }
        }
    }
