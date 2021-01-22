    // May throw FileNotFoundException, DirectoryNotFoundException,
    // IOException and more.
    try {
      using (StreamReader streamReader = new StreamReader(path)) {
        try {
          String line;
          // May throw IOException.
          while ((line = streamReader.ReadLine()) != null) {
            // May throw IndexOutOfRangeException.
            Char c = line[30];
            Console.WriteLine(c);
          }
        }
        catch (IOException ex) {
          Console.WriteLine("Error reading file: " + ex.Message);
        }
      }
    }
    catch (FileNotFoundException ex) {
      Console.WriteLine("File does not exists: " + ex.Message);
    }
    catch (DirectoryNotFoundException ex) {
      Console.WriteLine("Invalid path: " + ex.Message);
    }
    catch (IOException ex) {
      Console.WriteLine("Error reading file: " + ex.Message);
    }
