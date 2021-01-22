        static void Main(string[] args)
        {
            string directory = null;
            string filePattern = null;
            string sourceDirectory = null;
            string targetDirectory = null;
            List<string> version = null;
            string action = null;
            bool showHelp = false;
            for (int i = 0; i < args.Length; i++)
            {
                string parameterName;
                int colonIndex = args[i].IndexOf(':');
                if (colonIndex >= 0)
                    parameterName = args[i].Substring(0, colonIndex);
                else
                    parameterName = args[i];
                switch (parameterName.ToLower())
                {
                    case "-dir":
                    case "/dir":
                        if (colonIndex >= 0)
                        {
                            int valueStartIndex = colonIndex + 1;
                            directory = args[i].Substring(valueStartIndex, args[i].Length - valueStartIndex);
                        }
                        else
                        {
                            i++;
                            if (i < args.Length)
                            {
                                directory = args[i];
                            }
                            else
                            {
                                System.Console.WriteLine("Expected a directory to be specified with the dir parameter.");
                            }
                        }
                        break;
                    case "-sourcedir":
                    case "/sourcedir":
                        if (colonIndex >= 0)
                        {
                            int valueStartIndex = colonIndex + 1;
                            sourceDirectory = args[i].Substring(valueStartIndex, args[i].Length - valueStartIndex);
                        }
                        else
                        {
                            i++;
                            if (i < args.Length)
                            {
                                sourceDirectory = args[i];
                            }
                            else
                            {
                                System.Console.WriteLine("Expected a directory to be specified with the sourcedir parameter.");
                            }
                        }
                        break;
                    case "-targetdir":
                    case "/targetdir":
                        if (colonIndex >= 0)
                        {
                            int valueStartIndex = colonIndex + 1;
                            targetDirectory = args[i].Substring(valueStartIndex, args[i].Length - valueStartIndex);
                        }
                        else
                        {
                            i++;
                            if (i < args.Length)
                            {
                                targetDirectory = args[i];
                            }
                            else
                            {
                                System.Console.WriteLine("Expected a directory to be specified with the targetdir parameter.");
                            }
                        }
                        break;
                    case "-file":
                    case "/file":
                        if (colonIndex >= 0)
                        {
                            int valueStartIndex = colonIndex + 1;
                            filePattern = args[i].Substring(valueStartIndex, args[i].Length - valueStartIndex);
                        }
                        else
                        {
                            i++;
                            if (i < args.Length)
                            {
                                filePattern = args[i];
                            }
                            else
                            {
                                System.Console.WriteLine("Expected a file pattern to be specified with the file parameter.");
                                return;
                            }
                        }
                        break;
                    case "-action":
                    case "/action":
                        if (colonIndex >= 0)
                        {
                            int valueStartIndex = colonIndex + 1;
                            action = args[i].Substring(valueStartIndex, args[i].Length - valueStartIndex);
                        }
                        else
                        {
                            i++;
                            if (i < args.Length)
                            {
                                action = args[i];
                            }
                            else
                            {
                                System.Console.WriteLine("Expected an action to be specified with the action parameter.");
                                return;
                            }
                        }
                        break;
                    case "-version":
                    case "/version":
                        if (version == null)
                            version = new List<string>();
                        if (colonIndex >= 0)
                        {
                            int valueStartIndex = colonIndex + 1;
                            version.Add(args[i].Substring(valueStartIndex, args[i].Length - valueStartIndex));
                        }
                        else
                        {
                            i++;
                            if (i < args.Length)
                            {
                                version.Add(args[i]);
                            }
                            else
                            {
                                System.Console.WriteLine("Expected a version to be specified with the version parameter.");
                                return;
                            }
                        }
                        break;
                    case "-?":
                    case "/?":
                    case "-help":
                    case "/help":
                        showHelp = true;
                        break;
                    default:
                        System.Console.WriteLine("Unrecognized parameter \"{0}\".", parameterName);
                        return;
                }
            }
            // At this point, all of the command line arguments have been read
            // and used to populate the variables that I defined at the top.
            // The rest of my application will work with the variables
            // and will not reference to args array again.
        }
