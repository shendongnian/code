    protected override void OnStart(string[] args){
        string binpath = new System.IO.FileInfo(System.Reflection.Assembly.GetAssembly(this.GetType()).Location).DirectoryName + "\\";
        System.IO.StreamWriter sw = new System.IO.StreamWriter( binpath + "test.log");
        sw.WriteLine( binpath );
        string[] cmdArgs = System.Environment.GetCommandLineArgs();
        foreach (string item in cmdArgs) {
            sw.WriteLine(item);
        }
        sw.Flush();
        sw.Dispose();
        sw = null;
    }
