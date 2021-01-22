    private string[] ColeccionDeCortes(string Path)
    {
      DirectoryInfo X = new DirectoryInfo(Path);
      FileInfo[] listaDeArchivos = X.GetFiles();
      string[] Coleccion=new string[listaDeArchivos.Length];
      for (int i = 0; i < listaDeArchivos.Length; i++)
      {
         Coleccion[i] = listaDeArchivos[i].Name;
      }
      return Coleccion;
    }
