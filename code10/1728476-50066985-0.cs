    public class TestSchema
    {
        public static void GetSchema()
        {
            
            //using Newtonsoft.Json;
            //using Newtonsoft.Json.Schema;
            //using Newtonsoft.Json.Schema.Generation;
            //using Newtonsoft.Json.Serialization;
            JSchemaGenerator generator = new JSchemaGenerator();
            //Generator settings
            generator.GenerationProviders.Add(new StringEnumGenerationProvider());
            generator.DefaultRequired = Required.Default;
            generator.SchemaLocationHandling = SchemaLocationHandling.Inline;
            generator.SchemaReferenceHandling = SchemaReferenceHandling.All;
            generator.SchemaIdGenerationHandling = SchemaIdGenerationHandling.TypeName;
            generator.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //Kratos
            JSchema schema = generator.Generate(typeof(Kratos));
            string json = schema.ToString();
            System.Diagnostics.Debug.WriteLine(json);
            //Person
            schema = generator.Generate(typeof(Person));
            json = schema.ToString();
            System.Diagnostics.Debug.WriteLine(json);
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        private string hidden { get; set; }
    }
    public class Kratos
    {
        [JsonProperty(Required = Required.Always)]
        public static string Title = "God of War";
        public static string notIncluded = "Boo hoo";
        [JsonProperty(Required = Required.Always)]
        public const bool bWillHaveRevenge = true;
        //Yes
        public string mainWeapon = "Blades of Exile";
        [JsonProperty(Required = Required.Always)]
        private int nLivingFamily = 0;
        public GodsOfOlympus TopPriority = GodsOfOlympus.Zeus;
        public GodsOfOlympus KillableGods { get { return GodsOfOlympus.ALLTHEGODS; } }
        [JsonProperty]
        private GodsOfOlympus DefeatedGods = GodsOfOlympus.Poseidon | GodsOfOlympus.Hades;
        [Flags]
        public enum GodsOfOlympus : byte
        {
            Zeus = 0x1,
            Hades = 0x2,
            Poseidon = 0x4,
            Athena = 0x8,
            Hermes = 0x10,
            Helios = 0x20,
            Hera = 0x40,
            Aphrodite = 0x80,
            ALLTHEGODS = Zeus | Hades | Poseidon | Athena | Hermes | Helios | Hera | Aphrodite
        }
        public Kratos()
        {
            System.Diagnostics.Debug.WriteLine("KRAAAATOOOOSSS");
        }
    }
