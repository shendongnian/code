        public class PokemonData
        {
            public class Rootobject
            {
                public List<Ability> abilities { get; set; }
                public int Base_experience { get; set; }
                public List<Form> forms { get; set; }
                public List<Game_Indices> game_indices { get; set; }
                public int height { get; set; }
                public List<Held_Items> held_items { get; set; }
                public int id { get; set; }
                public bool is_default { get; set; }
                public string location_area_encounters { get; set; }
                public List<Move> Moves { get; set; }
                public string name { get; set; }
                public int order { get; set; }
                public Species species { get; set; }
                public Sprites sprites { get; set; }
                public List<Stat> stats { get; set; }
                public List<Type> types { get; set; }
                public int weight { get; set; }
            }
            public class Species
            {
                public string name { get; set; }
                public string url { get; set; }
            }
            // etc.
        }
    You would have this:
        public class PokemonData
        {
            public List<Ability> abilities { get; set; }
            public int Base_experience { get; set; }
            public List<Form> forms { get; set; }
            public List<Game_Indices> game_indices { get; set; }
            public int height { get; set; }
            public List<Held_Items> held_items { get; set; }
            public int id { get; set; }
            public bool is_default { get; set; }
            public string location_area_encounters { get; set; }
            public List<Move> Moves { get; set; }
            public string name { get; set; }
            public int order { get; set; }
            public Species species { get; set; }
            public Sprites sprites { get; set; }
            public List<Stat> stats { get; set; }
            public List<Type> types { get; set; }
            public int weight { get; set; }
        }
        public class Species
        {
            public string name { get; set; }
            public string url { get; set; }
        }
        // etc.
