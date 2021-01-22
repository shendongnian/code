    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        Connecter conn = new Connecter("a", "m");
        conn.PageDeleted += new Connecter.PageDeletedHandler(conn_PageDeleted);
        bool success = conn.DeletePage(txtPageToDelete.Text, chkRecursive.Checked);
    }
