        Process[] initial = Process.GetProcessesByName("notepad");
        foreach (Process i in initial)
        {
            if (!Clients.Contains(i.Id))
            {
                Clients.Add(i.Id);
                Console.WriteLine(i.Id + " was added.");
            }
        }
