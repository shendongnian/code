      private void AggregateTextFileIntoListView(String pathToFile)
      {
          using (TextReader tr = new StreamReader(pathToFile)))
                {
                    String line;
                    while ((line = tr.ReadLine()) != null)
                    {
                        //* let's delimiter be ";".
                        String[] lineParts = line.Split(';');
                        addLineToListView(lineParts[0], lineParts[1], lineParts[2]);
                    }
                    tr.Close();
                }
     }
