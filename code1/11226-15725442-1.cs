    // Run ping.exe asynchronously and return roundtrip times back to the caller in a callback
    public static void PingUrl(string url, Action<string> replyHandler)
    {
        var regex = new Regex("(time=|Average = )(?<time>.*?ms)", RegexOptions.Compiled);
        var app = new ConsoleApp("ping", url);
        app.ConsoleOutput += (o, args) =>
        {
            var match = regex.Match(args.Line);
            if (match.Success)
            {
                var roundtripTime = match.Groups["time"].Value;
                replyHandler(roundtripTime);
            }
        };
        app.Run();
    }
