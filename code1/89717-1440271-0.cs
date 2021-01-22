        private string[] ColeccionDeCortes(string Path)
        {
            DirectoryInfo X = new DirectoryInfo(Path);
            FileInfo[] listaDeArchivos = X.GetFiles();
            string[] Coleccion = new string[listaDeArchivos.Length];
            int i = 0;
            foreach (FileInfo FI in listaDeArchivos)
            {
                Coleccion[i++] = FI.Name;
                //Add the FI.Name to the Coleccion[] array, 
            }
            return Coleccion;
        }
