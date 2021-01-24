    var item = new Item
    {
        Version = 1,
        SchemaVersion = 2,
        Id = textBox14.Text,
        Title = textBox7.Text,
        TitleLocalized = textBox18.Text,
        Artist = textBox6.Text,
        ArtistLocalized = textBox8.Text,
        ArtistSource = textBox9.Text,
        Illustrator = textBox10.Text,
        IllustratorSource = textBox11.Text,
        Charter = textBox13.Text,
        Music = new ItemMusic
        {
            Path = textBox4.Text
        },
        MusicPreview = new ItemMusicPreview
        {
            Path = textBox5.Text
        },
        Background = new ItemBackground
        {
            Path = open3.FileName
        },
        Charts = new List<ItemChart>
        {
            new ItemChart
            {
                Type = "easy",
                Name = textBox15.Text,
                Difficulty = numericUpDown1.Value,
                Path = textBox1.Text
            },
            new ItemChart
            {
                Type = "hard",
                Name = textBox16.Text,
                Difficulty = numericUpDown2.Value,
                Path = textBox2.Text
            }
        }
    };
    var settings = new JsonSerializerSettings()
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        }
    };
    var json = JsonConvert.SerializeObject(item, settings);
    File.WriteAllText($@"C:\Users\Public\Desktop\level files\{textBox14.Text}\level.json", json, new UTF8Encoding(true));
