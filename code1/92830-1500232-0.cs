        string textReaderText = "TextReader is the abstract base " +
            "class of StreamReader and StringReader, which read " +
            "characters from streams and strings, respectively.\n\n" +
            "Create an instance of TextReader to open a text file " +
            "for reading a specified range of characters, or to " +
            "create a reader based on an existing stream.\n\n" +
            "You can also use an instance of TextReader to read " +
            "text from a custom backing store using the same " +
            "APIs you would use for a string or a stream.\n\n";
        Console.WriteLine("Original text:\n\n{0}", textReaderText);
        // From textReaderText, create a continuous paragraph 
        // with two spaces between each sentence.
        string aLine, aParagraph = null;
        StringReader strReader = new StringReader(textReaderText);
        while(true)
        {
            aLine = strReader.ReadLine();
            if(aLine != null)
            {
                aParagraph = aParagraph + aLine + " ";
            }
            else
            {
                aParagraph = aParagraph + "\n";
                break;
            }
        }
        Console.WriteLine("Modified text:\n\n{0}", aParagraph);
