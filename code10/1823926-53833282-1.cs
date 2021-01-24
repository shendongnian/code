    private void FakeRadioBehaviour(object sender, EventArgs e)
    {
        foreach (var DB in DBs)
        {
            //Checks the sender, unchecks all others ones.
            DB.Checked = ((sender as ToolStripMenuItem) == DB);
        }
    }
