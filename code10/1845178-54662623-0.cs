     string fileName = "The Animals - House of the Rising Sun ? (1964) + clip compilation ♫♥ 50 YEARS - counting.mp3";
            
     byte[] bytes = Encoding.ASCII.GetBytes(fileName);
     char[] characters = Encoding.ASCII.GetChars(bytes);
     string name = new string(characters);
     StringBuilder fileN = new StringBuilder(name);
     foreach (char c in Path.GetInvalidFileNameChars())
     {
         fileN.Replace(c, '_');
     }
     string validFileName = fileN.ToString();
