        public static async void Main(string[] args)
        {
            Uri Path = new Uri("https://pokeapi.co/api/v2/pokemon/ditto/");
            using (HttpClient Client = new HttpClient())
            {
                PokemonData.Rootobject PokemonInfo = await APIData(Client, Path);
                Console.WriteLine("Name: " + PokemonInfo.name);
                Console.WriteLine("Species: " + PokemonInfo.species.name);
                Console.WriteLine("Height: " + PokemonInfo.height);
                Console.WriteLine("Weight: " + PokemonInfo.weight);
                Console.WriteLine("Abilities: " + string.Join(", ", PokemonInfo.abilities.Select(a => a.ability.name)));
                // etc.
            }
        }
        public static async Task<PokemonData.Rootobject> APIData(HttpClient Client, Uri Address)
        {
            string JSONData = await Client.GetStringAsync(Address);
            PokemonData.Rootobject ReadyData = JsonConvert.DeserializeObject<PokemonData.Rootobject>(JSONData);
            return ReadyData;
        }
