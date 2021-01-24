        private void LoadAppointments()
    {
        // load all "Routine" appointments into the listbox
        string[] lines = File.ReadAllLines(@"D:\appointments.txt");
        string filter = "Routine";
        var filteredLines = lines.Where(line => line.Contains(filter)).ToList();
    }
