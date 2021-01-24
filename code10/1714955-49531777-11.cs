    private static void OnSpeechRecognized(object sender, SpeechRecognizedEventArgs e) {
        var sem = e.Result.Semantics;
        // here "command" is arbitrary key we assigned in our rule
        var commandName = (string) sem["command"].Value;
        switch (commandName) {
            // also arbitrary values we assigned, not related to rule names or something else
            case "settimer":
                var numSeconds = Convert.ToInt32(sem.Value);
                Console.WriteLine($"Starting timer for {numSeconds} seconds...");
                break;
            case "cleartimer":
                Console.WriteLine("timer cleared");
                break;
        }
    }
