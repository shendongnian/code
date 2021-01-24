    public IEnumerator Deserialize()
    {
        var dataPath = Path.Combine(Application.persistentDataPath, "Images");
        var bytes = new Dictionary<Item, byte[]>();
        var done = false;
        new Thread(() => {
            if (File.Exists(Path.Combine(dataPath, "images.json")))
            {
                var items = JsonConvert.DeserializeObject<Dictionary<string, Item>>(File.ReadAllText(Path.Combine(dataPath, "images.json"))).Values;
                foreach (var i in items)
                {
                    if (!File.Exists(Path.Combine(dataPath, i.Name))) continue;
                    var b = File.ReadAllBytes(Path.Combine(dataPath, i.Name));
                    if (b.Length <= 0) continue;
                    bytes.Add(i, b);
                }
            }
            done = true;
        }).Start();
        while (!done)
        {
            yield return null;
        }
        // MOD: added stopwatch and started
        System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        
        var result = new Dictionary<string, Item>();
        foreach (var b in bytes)
        {
            var texture = new Texture2D(2, 2);
            if (!texture.LoadImage(b.Value)) continue;
            b.Key.Texture = texture;
            result.Add(b.Key.Id, b.Key);
        }
        Debug.Log("Finished loading images!");
        Images = result;
        // (Konrad) Deserialize Projects.
        if (Projects == null) Projects = new List<Project>();
        if (File.Exists(Path.Combine(dataPath, "projects.json")))
        {
            var projects = JsonConvert.DeserializeObject<List<Project>>(File.ReadAllText(Path.Combine(dataPath, "projects.json")));
            if (projects != null)
            {
                foreach (var p in projects)
                {
                    AddProject(p);
                    foreach (var f in p.Folders)
                    {
                        AddFolder(f, true);
                        foreach (var i in f.Items)
                        {
                            var image = Images != null && Images.ContainsKey(i.ParentImageId)
                                ? Images[i.ParentImageId]
                                : null;
                            if (image == null) continue;
                            i.ThumbnailTexture = image.Texture;
                            // (Konrad) Call methods that would normally be called by the event system
                            // as content is getting downloaded.
                            AddItemThumbnail(i, true); // creates new button
                            UpdateImageDescription(i, image); // sets button description
                            AddItemContent(i, image); // sets item Material
                        }
                    }
                }
            }
        }
        if (Images == null) Images = new Dictionary<string, Item>();
        yield return true;
    }
