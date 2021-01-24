    using System;
    using System.Threading.Tasks;
    using NJsonSchema;
    using NJsonSchema.CodeGeneration.CSharp;
    
    namespace RunningTestings
    {
        class Program
        {
            static void Main(string[] args)
            {
                CreateClassfromJsonSchema(@"http://files.developer.sabre.com/doc/providerdoc/STPS/bfm/v410/OTA_AirLowFareSearchRQ.jsonschema").Wait();
            }
    
            public static async Task CreateClassfromJsonSchema(string url)
            {
                JsonSchema4 jsonSchema = await JsonSchema4.FromUrlAsync(url);
                CSharpGenerator generator = new CSharpGenerator(jsonSchema);
                string file = generator.GenerateFile();
            }
        }
    }
