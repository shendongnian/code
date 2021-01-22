    private void button_Click(object sender, EventArgs e)
    {
        // pass in the containing panel
        LoadControl<MyControls.MyControl>(panelContainer);
    }
    
    void LoadControl<T>(Panel panel) where T : Control, new()
    {
        T _Control = GetControl<T>(panel);
        if (_Control == null)
        {
            _Control = new T();
            _Control.Dock = DockStyle.Fill;
            panel.Controls.Add(_Control);
        }
        _Control.BringToFront();
    }
    
    T GetControl<T>(Panel panel) where T : Control
    {
        Type _Type = typeof(T);
        String _Name = _Type.ToString();
        if (!panel.Controls.ContainsKey(_Name))
            return null;
        T _Control = panel.Controls[_Name] as T;
        return _Control;
    }
