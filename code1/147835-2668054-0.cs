    void PrintTOC(string prefix, List<Sections> sections) {
      // Iterate over all sections at the current level (e.g. "2")
      for(int i = 0; i<sections.Length; i++) {
        // Get prefix for the current section (e.g. "2.1")
        string num = String.Format("{0}.{1}", prefix, i+1);
        // Write the current section title
        Console.WriteLine("{0} {1}", num, sections[i].Titles);
        
        // Recursively process all children, passing "2.1" as the prefix
        if (sections[i].Children != null)
          PrintTOC(num, sections[i].Children);
      }
    }
