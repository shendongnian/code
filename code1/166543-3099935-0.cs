    Assembly asm = Assembly.GetExecutingAssembly();
    if( asm != null && !string.IsNullOrEmpty(asm.Location) ) {
       FileInfo info = new FileInfo(asm.Location);
       DateTime date = info.CreationTime;
    }
