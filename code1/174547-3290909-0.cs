    static void Set(TopshelfArguments args, IEnumerable<ICommandLineElement> commandLineElements)
        {
            var command = commandLineElements
                .Take(1)
                .Select(x => (ISwitchElement) x) 
                .Select(x => x.Key)
                .DefaultIfEmpty("commandline")
                .SingleOrDefault();
    
    
            args.Command = command;
            //leftovers
            args.CommandArgs = commandLineElements.Skip(1).ToList();
        }
