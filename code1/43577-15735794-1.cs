    List<Control> controls = new List<Control>();
    foreach (Control control in tableLayoutPanelEnderecoDetalhes.Controls)
    {
        controls.Add(control);
    }
    foreach (Control control in controls)
    {
        control.Dispose();
    }
