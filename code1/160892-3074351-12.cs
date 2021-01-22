    public class GenerateCodeFromXyzFiles : ITask
    {
      public IBuildEngine BuildEngine { get; set; }
      public ITaskHost HostObject { get; set; }
      public ITaskItem[] InputFiles { get; set; }
      public ITaskItem[] OutputFiles { get; set; }
      public bool Execute()
      {
        for(int i=0; i<InputFiles.Length; i++)
          File.WriteAllText(OutputFiles[i].ItemSpec,
            ProcessXyzFile(
              File.ReadAllText(InputFiles[i].ItemSpec)));
      }
      private string ProcessXyzFile(string xyzFileContents)
      {
        // Process file and return generated code
      }
    }
