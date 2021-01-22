    private delegate void ParameterlessVoid();
    private void RefreshDataGridViewThreadSafe()
    {
        if (this.dataGridView.InvokeRequired)
        {
            this.dataGridView.Invoke(new ParameterlessVoid(this.RefreshDataGridView));
        }
        else
        {
            this.RefreshDataGridView();
        }
    }
    private void RefreshDataGridView()
    {
        this.dataGridView.Refresh();
    }
