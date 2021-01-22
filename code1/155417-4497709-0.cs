      Sub ReadRessourceFile()
            Dim rsxr As System.Resources.ResXResourceReader 'Requires Assembly System.Windows.Forms
            rsxr = New System.Resources.ResXResourceReader("items.resx")
    
            ' Iterate through the resources and display the contents to the console.
    
            Dim d As System.Collections.DictionaryEntry
            For Each d In rsxr
                Console.WriteLine(d.Key.ToString() + ":" + ControlChars.Tab + d.Value.ToString())
            Next d
    
            'Close the reader.
            rsxr.Close()
        End Sub
