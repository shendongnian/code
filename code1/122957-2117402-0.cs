    Assembly asm = Assembly.GetExecutingAssembly();
    for(int i = 1; i <= 30; i++)
    {
      Stream file = asm.GetManifestResourceStream("NameSpace.Resources.Image"+i.ToString("000")+".png");
      // Do something or store the stream
    }
