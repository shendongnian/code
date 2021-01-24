    public void LoadObjectsFromJsonFile()
        {
            string SolutionPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string Filepath = SolutionPath + "\\Resources\\movies-filtered.json";
            using (StreamReader Sr = new StreamReader(Filepath))
            {
                var Json = Sr.ReadToEnd();
                Movies = JsonConvert.DeserializeObject<List<Movie>>(Json);
            }
            LoadActors();
        }
