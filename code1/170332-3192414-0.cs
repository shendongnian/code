    public class GenerateDesignerDC : Task
    {
        [Required]
        public ITaskItem[] InputFiles { get; set; }
        
        [Output]
        public ITaskItem[] OutputFiles { get; set; }
    
        public override bool Execute()
        {
            var generatedFileNames = new List<string>();
            foreach (var task in InputFiles)
            {
    
                string inputFileName = task.ItemSpec;
                string outputFileName = Path.ChangeExtension(inputFileName, ".Designer.cs");
                string result;
    
                // Build code string
                var generator = new ULinqCodeGenerator("CSharp");
                string fileContent;
                using (FileStream fs = File.OpenRead(inputFileName))
                using (StreamReader rd = new StreamReader(fs))
                {
                    fileContent = rd.ReadToEnd();
                }
    
                using (var destination = new FileStream(outputFileName, FileMode.Create))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(generator.BuildCode(inputFileName, fileContent));
                    destination.Write(bytes, 0, bytes.Length);
                }
                generatedFileNames.Add(outputFileName);
            }
    
            OutputFiles = generatedFileNames.Select(name => new TaskItem(name)).ToArray();
    
            return true;
        }
    }
