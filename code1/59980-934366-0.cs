    private bool SelectionIsContiguous(ListBox lb)
    {
        for (int i = 0; i < lb.SelectedIndices.Count - 1; i++)
            if (lb.SelectedIndices[i] < lb.SelectedIndices[i + 1] - 1)
                return false;
    
        return true;
    }
    
    private void SetMoveButtonStates()
    {
        if (this.listBox.SelectedIndices.Count > 0)
        {
            if (this.listBox.SelectedIndices.Count > 1 && !SelectionIsContiguous(this.listBox))
            {
                this.btnMoveUp.Enabled = false;
                this.btnMoveDown.Enabled = false;
                return;
            }
    
            int firstSelectedIndex = this.listBox.SelectedIndices[0];
            this.btnMoveUp.Enabled = firstSelectedIndex == 0 ? false : true;
    
            int lastIndex = this.listBox.Items.Count - 1;
            int lastSelectedIndex = this.listBox.SelectedIndices[this.listBox.SelectedIndices.Count - 1];
            this.btnMoveDown.Enabled = lastSelectedIndex == lastIndex ? false : true;
        }
    }
