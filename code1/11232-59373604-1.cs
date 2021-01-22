    RunProcess(
        executable,
        args,
        s => { Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(s); },
        s => { Console.ForegroundColor = ConsoleColor.Red;   Console.WriteLine(s); } 
    );
