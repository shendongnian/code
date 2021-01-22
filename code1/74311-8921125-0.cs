    //does not work
    OpenFileDialog dlgOpen = new OpenFileDialog();
    string initPath = Path.GetTempPath() + @"\FQUL";
    dlgOpen.InitialDirectory = initPath;
    dlgOpen.RestoreDirectory = true;
    //works
    OpenFileDialog dlgOpen = new OpenFileDialog();
    string initPath = Path.GetTempPath() + @"\FQUL";
    dlgOpen.InitialDirectory = Path.GetFullPath(initPath);
    dlgOpen.RestoreDirectory = true;
