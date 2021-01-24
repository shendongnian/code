    private void newLocalUserToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Newuserform formnewuser = new Newuserform();
        formnewuser.UnameChanged += Handler;
        formnewuser.Show();
    }
    private void Handler (object sender, string Uname)
    {
        // do something wit the new Uname.
    }
