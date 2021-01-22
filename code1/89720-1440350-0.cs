    using System.Collections.Specialized;
    private StringCollection ColeccionDeCortes(string Path)   
    {
        DirectoryInfo X = new DirectoryInfo(Path);
        FileInfo[] listaDeArchivos = X.GetFiles();
        StringCollection Coleccion = new StringCollection();
 
        foreach (FileInfo FI in listaDeArchivos)
        {
            Coleccion.Add( FI.Name );
        }
        return Coleccion;
    }
