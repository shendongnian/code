    public class CommentAttribute : Attribute
    {
        public CommentAttribute(string comment)
        {
            this.Comment = comment;
        }
        public string Comment { get; set; }
    }
    public class GenerateResourceAttribute : Attribute
    {
        public string FileName { get; set; }
    }
    public class ResourceGenerator
    {
        public ResourceGenerator(IEnumerable<Assembly> assemblies)
        {
            // Loop over the provided assemblies.
            foreach (var assembly in assemblies)
            {
                // Loop over each type in the assembly.
                foreach (var type in assembly.GetTypes())
                {
                    // See if the type has the GenerateResource attribute.
                    var attribute = type.GetCustomAttribute<GenerateResourceAttribute>(false);
                    if (attribute != null)
                    {
                        // If so determine the output directory.  First assume it's the current directory.
                        var outputDirectory = Directory.GetCurrentDirectory();
                        // Is this assembly part of the output directory?
                        var index = outputDirectory.LastIndexOf(typeof(ResourceGenerator).Assembly.GetName().Name);
                        if (index >= 0)
                        {
                            // If so remove it and anything after it.
                            outputDirectory = outputDirectory.Substring(0, index);
                            // Is the concatenation of the output directory and the target assembly name not a directory?
                            outputDirectory = Path.Combine(outputDirectory, type.Assembly.GetName().Name);
                            if (!Directory.Exists(outputDirectory))
                            {
                                // If that is the case make it the current directory. 
                                outputDirectory = Directory.GetCurrentDirectory();
                            }
                        }
                        // Use the default file name (Type + "Resources") if one was not provided.
                        var fileName = attribute.FileName;
                        if (fileName == null)
                        {
                            fileName = type.Name + "Resources";
                        }
                        // Add .resx to the end of the file name.
                        fileName = Path.Combine(outputDirectory, fileName);
                        if (!fileName.EndsWith(".resx", StringComparison.InvariantCultureIgnoreCase))
                        {
                            fileName += ".resx";
                        }
                        using (var resx = new ResXResourceWriter(fileName))
                        {
                            var tuples = this.GetTuplesRecursive("", type).OrderBy(t => t.Item1);
                            foreach (var tuple in tuples)
                            {
                                var key = tuple.Item1 + tuple.Item2.Name;
                                var value = tuple.Item2.GetValue(null);
                                string comment = null;
                                var commentAttribute = tuple.Item2.GetCustomAttribute<CommentAttribute>();
                                if (commentAttribute != null)
                                {
                                    comment = commentAttribute.Comment;
                                }
                                resx.AddResource(new ResXDataNode(key, value) { Comment = comment });
                            }
                        }
                    }
                }
            }
        }
        private IEnumerable<Tuple<string, FieldInfo>> GetTuplesRecursive(string prefix, Type type)
        {
            // Get the properties for the current type.
            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                yield return new Tuple<string, FieldInfo>(prefix, field);
            }
            // Get the properties for each child type.
            foreach (var nestedType in type.GetNestedTypes())
            {
                foreach (var tuple in this.GetTuplesRecursive(prefix + nestedType.Name, nestedType))
                {
                    yield return tuple;
                }
            }
        }
    }
