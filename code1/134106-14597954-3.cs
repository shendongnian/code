    #region Usage from MainForm
    if (!ScriptTextBox.Visible)
    {
        ScriptTextBox.Text = ScriptRunner.LoadScript(@"Scripts\Template.cs");
        ScriptTextBox.Visible = true;
    }
    else // if visible
    {
        string source_code = ScriptTextBox.Text;
        if (source_code.Length > 0)
        {
            Assembly compiled_assembly = ScriptRunner.CompileCode(source_code);
            if (compiled_assembly != null)
            {
                object[] args = new object[] { m_client, m_client.Selection.Verses, "19" };
                object result = ScriptRunner.Run(compiled_assembly, args);
                // process result here
            }
        }
        ScriptTextBox.Visible = false;
    }
    #endregion
