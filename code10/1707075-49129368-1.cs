    public static class ScriptParser
    {
        public static void Parse(string filename)
        {
            string[] script = null;
            using (StreamReader reader = File.OpenText(filename))
            {
                // read the whole file, remove all line breaks and split 
                // by semicolons to get individual commands
                script = reader.ReadToEnd().Replace("\r", string.Empty.Replace("\n", string.Empty)).Split(';');
            }
            foreach (string command in script)
                HandleCommand(command);
        }
        // as arguments seem to be grouped you can't just split
        // by commas so this will get the arguments recursively
        private static object[] ParseArgs(string argsString)
        {
            int startPos = 0;
            int depth = 0;
            List<object> args = new List<object>();
            Action<int> addArg = pos =>
            {
                string arg = argsString.Substring(startPos, pos - startPos).Trim();
                if (arg.StartsWith("{") && arg.EndsWith("}"))
                {
                    arg = arg.Substring(1, arg.Length - 2);
                    args.Add(ParseArgs(arg));
                }
                else
                {
                    args.Add(arg);
                }
            }
            for (int i = 0; i < argsString.Length; i++)
            {
                switch (argsString[i])
                {
                    case ',':
                        if (depth == 0)
                        {
                            addArg(i);
                            startPos = i + 1;
                        }
                        break;
                    case '{':
                        // increase depth of parsing so that commas
                        // within braces are ignored
                        depth++;
                        break;
                    case '}':
                        // decrease depth when exiting braces
                        depth--;
                        break;
                }
            }
            // as there is no final comma
            addArg(argsString.Length);
            return args.ToArray();
        }
        private static void HandleCommand(string commandString)
        {
            Command command = new Command();
            string prefix = commandString.Substring(0, commandString.IndexOf("("));
            command.Collection = prefix.Split('.')[0];
            command.Action = prefix.Split('.')[1];
            string commandArgs = commandString.Substring(commandString.IndexOf("("));
            commandArgs = commandArgs.Substring(1, commandArgs.Length - 2);
            command.Args = ParseArgs(commandArgs);
            command.Execute();
        }
        private class Command
        {
            public string Collection;
            public string Action;
            public object[] Args;
            public void Execute()
            {
                // need to handle any expected commands
                if (Collection == "buildings")
                {
                    if (Action == "addWithMaterials")
                    {
                        buildings.AddWithMaterials((string)Args[0], (object[])Args[1]);
                    }
                }
            }
        }
        //Eg.
        public static BuildingCollection buildings = new BuildingCollection();
        public class BuildingCollection
        {
            public void AddWithMaterials(string building, object[] materials)
            {
                Building building = new Building();
                foreach (object[] materialsPart in materials)
                    // more stuff for you to work out
                    // you will need to match the strings to material classes
            }
        }
    }
