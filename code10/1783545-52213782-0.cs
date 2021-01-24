    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace MinecraftClient
    {
        class Utilities
        {
            private static Dictionary<string, string> whitelisted;
    
            static Utilities()
            {
                string json = File.ReadAllText("whitelists/walls.json");
                var data = JsonConvert.DeserializeObject<dynamic>(json);
                whitelisted = data.ToObject<Dictionary<string, string>>();
            }
    
            public static ulong GetWhitelisted(string key)
            {
                if (whitelisted.ContainsKey(MinecraftClient.ChatBots.WeeWoo.username))
                {
                    ulong parsedId;
                    if (UInt64.TryParse(key, out parsedId))
                        return parsedId;                    
                }
                return 0;
            }
        }
    }
