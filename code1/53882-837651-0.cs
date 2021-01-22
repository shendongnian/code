    private void DoCopy(Control control)
    {
        if(control is ContainerControl)
            DoCopy(control.SelectedControl);
        else if(control is MyCustomControl)
            ((MyCustomControl)control).Copy();
        else if(control is RichTextBox)
            ((RichTextBox)control).Copy();
        else
            throw new NotSupportedException("The selected control can't copy!");
    }
    void menuEditCopy_Click(object sender, EventArgs e)
    {
        DoCopy(this.ActiveControl);
    }
