        public static ImageSource ImageFromResources(string subfolder, string filename)
        {
            var generatedFilename = AssemblyName + $".Images.{subfolder}.{filename}";
            return ImageSource.FromResource(generatedFilename);
        }
