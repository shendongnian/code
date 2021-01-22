    public Form1()
    {
        eventos = cliente.GetEventsTypes(usuario);
        foreach (EventNo no in eventos)
        {
            cboEventos.Items.Add(no.eventno.ToString() + "--" +no.description.ToString());
            cboEventos2.Items.Add(no.eventno.ToString());
        }
    }
    private void lista_SelectedIndexChanged(object sender, EventArgs e)
    {
        lista2.Items.Add(lista.SelectedItem.ToString());
    }
    private void cboEventos_SelectedIndexChanged(object sender, EventArgs e)
    {
        cboEventos2.SelectedIndex = cboEventos.SelectedIndex;
    }
