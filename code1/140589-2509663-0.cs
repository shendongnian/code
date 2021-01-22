    string line;
    using (StreamReader reader = new StreamReader ("/proc/" + p.Id + "/stat")) {
          line = reader.ReadLine ();
    }
    string [] parts = line.Split (new char [] {' '}, 5); // Only interested in field at position 3
    if (parts.Legth >= 4) {
        int ppid = Int32.Parse (parts [3]);
        if (ppid == parent.Id) {
             // Found a children
        }
    }
