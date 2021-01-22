    public static void Write(params string[] stringsToWrite) {
        ...    
        foreach (string stringToWrite in stringsToWrite) {
            writer.Write(" " + stringToWrite + " ");
        }
    
        ...
    }
