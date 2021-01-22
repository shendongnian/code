    protected void RestartButton_Click(object sender, EventArgs e)
    {
        //restart web app (instead of iisreset)
        DirectoryInfo dir = new DirectoryInfo(Server.MapPath("restart"));
        if (dir.Exists)
        {
            Directory.Move(dir.FullName, dir.FullName + "ed");
        }
        else
        {
            DirectoryInfo dired = new DirectoryInfo(Server.MapPath("restarted"));
            if (dired.Exists)
            {
                Directory.Move(dired.FullName, dir.FullName);
            }
            else
            {
                Directory.CreateDirectory(dir.FullName);
            }
        }
    }
