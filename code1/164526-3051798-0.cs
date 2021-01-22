    public IList<string> GetMatchingImages(string path, string keyword)
        {
            var matches = new List<string>();
    
            var images = System.IO.Directory.GetFiles("c:\whatever\");
    
            foreach (var image in images)
            {
                if (image.Contains(keyword))
                {
                    matches.Add(image);
                }
            }
    
            return matches;
        }
