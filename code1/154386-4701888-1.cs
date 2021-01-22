    // Load the file
    IniDocument doc = new IniDocument ("test.ini");
    
    // Print the data from the keys
    Console.WriteLine ("Key 1: " + doc.Get ("My Section", "key 1"));
    Console.WriteLine ("Key 2: " + doc.Get ("Pets", "dog"));
    
    // Create a new section
    doc.SetSection ("Movies");
    
    // Set new values in the section
    doc.SetKey ("Movies", "horror", "Scream");
    doc.SetKey ("Movies", "comedy", "Dumb and Dumber");
    
    // Remove a section or values from a section
    doc.RemoveSection ("My Section");
    doc.RemoveKey ("Pets", "dog");
    
    // Save the changes
    doc.Save("test.ini");
