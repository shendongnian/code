      // Create an IDictionaryEnumerator to iterate through the resources.
      IDictionaryEnumerator id = rsxr.GetEnumerator();       
      // Iterate through the resources and display the contents to the console.
      foreach (DictionaryEntry d in rsxr) 
      {
    Console.WriteLine(d.Key.ToString() + ":\t" + d.Value.ToString());
      }
     //Close the reader.
     rsxr.Close();
