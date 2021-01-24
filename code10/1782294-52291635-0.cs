    private void ShowControls(Control.ControlCollection controlCollection)
        {
            foreach (Control c in controlCollection)
            {
                if (c.Controls.Count > 0)
                {
                    ShowControls(c.Controls);
                }
                if (c is MenuStrip)
                {
                    MenuStrip menuStrip = c as MenuStrip;
                    ShowToolStripItems(menuStrip.Items);
                }
                if (c is Panel)
                {
                    formToolTip2.SetToolTip(c, c.Name);
                    PageControls.Items.Add(c.Name);
                }
                if (c is Button || c is ComboBox || c is TextBox ||
                    c is ListBox || c is DataGridView || c is RadioButton ||
                    c is RichTextBox || c is TabPage || c is CheckBox || c is ToolStrip)
                {
                    var toolstrips = controlCollection.OfType<ToolStrip>();
                    foreach (ToolStrip ts in toolstrips)
                    {
                        foreach (ToolStripItem tsi in ts.Items)
                        {
                            if (ts.Items.Count > 0)
                            {
                                if (tsi is ToolStripButton)
                                {
                                    ToolStripButton tb = tsi as ToolStripButton;
                                    tb.ToolTipText = tb.Name;
                                    if (!PageControls.Items.Contains(tb.Name))
                                    {
                                        PageControls.Items.Add(tb.Name);
                                    }
                                }
                            }
                        }
                    }
                    formToolTip2.SetToolTip(c, c.Name);
                    PageControls.Items.Add(c.Name);
                }
            }
        }
