    /// <summary>
    /// Methode, die einen Binärvergleich von 2 Dateien macht und
    /// das Vergleichsergebnis zurückliefert.
    /// </summary>
    /// <param name="p_FileA">Voll qualifizierte Pfadangabe zur ersten Datei.</param>
    /// <param name="p_FileB">Voll qualifizierte Pfadangabe zur zweiten Datei.</param>
    /// <returns>True, wenn die Dateien binär gleich sind, andernfalls False.</returns>
    private static bool FileDiffer(string p_FileA, string p_FileB)
    {
        bool retVal = true;
        FileInfo infoA = null;
        FileInfo infoB = null;
        byte[] bufferA = new byte[128];
        byte[] bufferB = new byte[128];
        int bufferRead = 0;
    
        // Die Dateien überprüfen
        if (!File.Exists(p_FileA))
        {
            throw new ArgumentException(String.Format("Die Datei '{0}' konnte nicht gefunden werden", p_FileA), "p_FileA");
        }
        if (!File.Exists(p_FileB))
        {
            throw new ArgumentException(String.Format("Die Datei '{0}' konnte nicht gefunden werden", p_FileB), "p_FileB");
        }
    
        // Dateiinfo wegen der Dateigröße erzeugen
        infoA = new FileInfo(p_FileA);
        infoB = new FileInfo(p_FileB);
    
        // Wenn die Dateigröße gleich ist, dann einen Vergleich anstossen
        if (infoA.Length == infoB.Length)
        {
            // Binärvergleich
            using (BinaryReader readerA = new BinaryReader(File.OpenRead(p_FileA)))
            {
                using (BinaryReader readerB = new BinaryReader(File.OpenRead(p_FileB)))
                {
                    // Dateistream blockweise über Puffer einlesen
                    while ((bufferRead = readerA.Read(bufferA, 0, bufferA.Length)) > 0)
                    {
                        // Dateigrößen sind gleich, deshalb kann hier
                        // ungeprüft auch von der 2. Datei eingelesen werden
                        readerB.Read(bufferB, 0, bufferB.Length);
    
                        // Bytevergleich innerhalb des Puffers
                        for (int i = 0; i < Math.Min(bufferA.Length, bufferRead); i++)
                        {
                            if (bufferA[i] != bufferB[i])
                            {
                                retVal = false;
                                break;
                            }
                        }
    
                        // Wenn Vergleich bereits fehlgeschlagen, dann hier schon abbruch
                        if (!retVal)
                        {
                            break;
                        }
                    }
                }
            }
        }
        else
        {
            // Die Dateigröße ist schon unterschiedlich
            retVal = false;
        }
    
        return retVal;
    }
