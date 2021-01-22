    public void txtPath_CheckKeys(object sender, KeyPressEventArgs kpe)
    {
        if (kpe.KeyCode == Keys.Escape)
        {
            _path = _oldPath;
            this.txtPath.Text = _path;
        }
    }
