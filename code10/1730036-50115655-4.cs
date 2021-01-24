    // using Newtonsoft.Json.Linq
    var json = new JObject();
    json.Add("Category", "Missile");
    json.Add("Type", "LRM");
    json.Add("WeaponSubType", "LRM20");
    var desc = new JObject();
    desc.Add("Cost", 180000);
    desc.Add("Rarity", 0);
    json.Add("Description", desc);
    var jsonstring = json.ToString(Newtonsoft.Json.Formatting.Indented);
