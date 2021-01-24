    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var example = new Config
                {
                    config_item = new Config_Item
                    {
                        LevelfieldValuesParshed = new CleanLevelfield_Values
                        {
                            Id = 2,
                            product = 1232
                        }
                    }
                };
                var serialized = JsonConvert.SerializeObject(example); // should have "product_2" : 2 inside
                // VOILA deserialization with property parsing in a clean object
                var deserialzed = JsonConvert.DeserializeObject<Config>(serialized);
                if (example.config_item.LevelfieldValuesParshed.Id != deserialzed.config_item.LevelfieldValuesParshed.Id || 
                    example.config_item.LevelfieldValuesParshed.product != deserialzed.config_item.LevelfieldValuesParshed.product)
                {
                    throw new Exception("Impossible to happen!!!");
                }
            }
        }
    
        public class Config
        {
            public Config_Item config_item { get; set; }
        }
    
        public class Config_Item
        {
            public int agent_id { get; set; }
            public string asset_tag { get; set; }
            public DateTime assigned_on { get; set; }
            public int ci_type_id { get; set; }
            public DateTime created_at { get; set; }
            public bool deleted { get; set; }
            public int department_id { get; set; }
            public object depreciation_id { get; set; }
            public object description { get; set; }
            public bool disabled { get; set; }
            public int display_id { get; set; }
            public bool expiry_notified { get; set; }
            public int id { get; set; }
            public int impact { get; set; }
            public int location_id { get; set; }
            public string name { get; set; }
            public object salvage { get; set; }
            public bool trashed { get; set; }
            public DateTime updated_at { get; set; }
            public int user_id { get; set; }
            public string department_name { get; set; }
            public string used_by { get; set; }
            public string business_impact { get; set; }
            public string agent_name { get; set; }
    
            // Regenerative property with backing filed => _levelfieldValuesParshed
            [JsonIgnore]  // Ignore property at serialization
            public CleanLevelfield_Values LevelfieldValuesParshed
            {
                get
                {
                    if (_levelfieldValuesParshed == null)
                    {
                        if (_levelfield_values != null) // if null everything is null
                        {
                            var propsByName = (IDictionary<string, object>)_levelfield_values; // Expando Object to dictionary
                            var product = propsByName.Keys.FirstOrDefault(x => x.StartsWith("product_", StringComparison.InvariantCultureIgnoreCase)); // user first to fail if not found, it can be smarter but it works
                            if (!string.IsNullOrEmpty(product))// hurray we know the id
                            {
                                if (int.TryParse(product.Replace("product_", ""), out int id)) // C# 7
                                {
                                    // Cleaner code can be written (generic method to set get object props with reflection)
                                    _levelfieldValuesParshed = new CleanLevelfield_Values
                                    {
                                        Id = id
                                    };
                                    _levelfieldValuesParshed.product = !string.IsNullOrEmpty(propsByName.Keys.FirstOrDefault(x => x.Equals($"product_{id}", StringComparison.InvariantCultureIgnoreCase)))
                                        ? Convert.ToInt32(propsByName.First(x => x.Key.Equals($"product_{id}", StringComparison.InvariantCultureIgnoreCase)).Value) : 0;
                                    _levelfieldValuesParshed.vendor = !string.IsNullOrEmpty(propsByName.Keys.FirstOrDefault(x => x.Equals($"vendor_{id}", StringComparison.InvariantCultureIgnoreCase)))
                                    ? Convert.ToInt32(propsByName.First(x => x.Key.Equals($"vendor_{id}", StringComparison.InvariantCultureIgnoreCase)).Value) : 0;
                                    _levelfieldValuesParshed.cost = !string.IsNullOrEmpty(propsByName.Keys.FirstOrDefault(x => x.Equals($"cost_{id}", StringComparison.InvariantCultureIgnoreCase)))
                                        ? Convert.ToInt32(propsByName.First(x => x.Key.Equals($"cost_{id}", StringComparison.InvariantCultureIgnoreCase)).Value) : 0;
                                    _levelfieldValuesParshed.license_validity = !string.IsNullOrEmpty(propsByName.Keys.FirstOrDefault(x => x.Equals($"license_validity_{id}", StringComparison.InvariantCultureIgnoreCase)))
                                        ? Convert.ToInt32(propsByName.First(x => x.Key.Equals($"license_validity_{id}", StringComparison.InvariantCultureIgnoreCase)).Value) : 0;
                                    _levelfieldValuesParshed.installation_date = !string.IsNullOrEmpty(propsByName.Keys.FirstOrDefault(x => x.Equals($"installation_date_{id}", StringComparison.InvariantCultureIgnoreCase)))
                                        ? Convert.ToDateTime(propsByName.First(x => x.Key.Equals($"installation_date_{id}", StringComparison.InvariantCultureIgnoreCase)).Value) : DateTime.MinValue;
                                    _levelfieldValuesParshed.license_expiry_date = !string.IsNullOrEmpty(propsByName.Keys.FirstOrDefault(x => x.Equals($"license_expiry_date_{id}", StringComparison.InvariantCultureIgnoreCase)))
                                        ? Convert.ToDateTime(propsByName.First(x => x.Key.Equals($"license_expiry_date_{id}", StringComparison.InvariantCultureIgnoreCase)).Value) : DateTime.MinValue;
                                    _levelfieldValuesParshed.license_key = !string.IsNullOrEmpty(propsByName.Keys.FirstOrDefault(x => x.Equals($"license_key_{id}", StringComparison.InvariantCultureIgnoreCase)))
                                        ? Convert.ToString(propsByName.First(x => x.Key.Equals($"license_key_{id}", StringComparison.InvariantCultureIgnoreCase)).Value) : string.Empty;
                                    _levelfieldValuesParshed.version = !string.IsNullOrEmpty(propsByName.Keys.FirstOrDefault(x => x.Equals($"version_{id}", StringComparison.InvariantCultureIgnoreCase)))
                                        ? Convert.ToInt32(propsByName.First(x => x.Key.Equals($"version_{id}", StringComparison.InvariantCultureIgnoreCase)).Value) : 0;
                                    _levelfieldValuesParshed.license_type = !string.IsNullOrEmpty(propsByName.Keys.FirstOrDefault(x => x.Equals($"license_type_{id}", StringComparison.InvariantCultureIgnoreCase)))
                                        ? Convert.ToString(propsByName.First(x => x.Key.Equals($"license_type_{id}", StringComparison.InvariantCultureIgnoreCase)).Value) : string.Empty;
                                    _levelfieldValuesParshed.installed_machine = !string.IsNullOrEmpty(propsByName.Keys.FirstOrDefault(x => x.Equals($"installed_machine_{id}", StringComparison.InvariantCultureIgnoreCase)))
                                        ? Convert.ToString(propsByName.First(x => x.Key.Equals($"installed_machine_{id}", StringComparison.InvariantCultureIgnoreCase)).Value) : string.Empty;
                                    _levelfieldValuesParshed.installation_path = !string.IsNullOrEmpty(propsByName.Keys.FirstOrDefault(x => x.Equals($"installation_path_{id}", StringComparison.InvariantCultureIgnoreCase)))
                                        ? propsByName.First(x => x.Key.Equals($"installation_path_{id}", StringComparison.InvariantCultureIgnoreCase)).Value : new object();
                                    _levelfieldValuesParshed.last_audit_date = !string.IsNullOrEmpty(propsByName.Keys.FirstOrDefault(x => x.Equals($"last_audit_date_{id}", StringComparison.InvariantCultureIgnoreCase)))
                                        ? Convert.ToDateTime(propsByName.First(x => x.Key.Equals($"last_audit_date_{id}", StringComparison.InvariantCultureIgnoreCase)).Value) : DateTime.MinValue;
                                }
                            }
                        }
                    }
                    return _levelfieldValuesParshed;
                }
                set
                {
                    _levelfieldValuesParshed = value;
                    _levelfield_values = null;
                }
            }
            private CleanLevelfield_Values _levelfieldValuesParshed;
    
            // Regenerative Expando property with backing field => _levelfield_values
            public System.Dynamic.ExpandoObject levelfield_values
            {
                get
                {
                    if (_levelfieldValuesParshed != null)
                    {
                        _levelfield_values = new ExpandoObject();
                        // Cleaner code can be written with a foreach (generic method to set get object props with reflection)
                        var keValuesPairs = (IDictionary<string, object>)_levelfield_values;
                        keValuesPairs.Add($"product_{_levelfieldValuesParshed.Id}", _levelfieldValuesParshed.product);
                        keValuesPairs.Add($"vendor_{_levelfieldValuesParshed.Id}", _levelfieldValuesParshed.vendor);
                        keValuesPairs.Add($"cost_{_levelfieldValuesParshed.Id}", _levelfieldValuesParshed.cost);
                        keValuesPairs.Add($"license_validity_{_levelfieldValuesParshed.Id}", _levelfieldValuesParshed.license_validity);
                        keValuesPairs.Add($"installation_date_{_levelfieldValuesParshed.Id}", _levelfieldValuesParshed.installation_date);
                        keValuesPairs.Add($"license_expiry_date_{_levelfieldValuesParshed.Id}", _levelfieldValuesParshed.license_expiry_date);
                        keValuesPairs.Add($"license_key_{_levelfieldValuesParshed.Id}", _levelfieldValuesParshed.license_key);
                        keValuesPairs.Add($"version_{_levelfieldValuesParshed.Id}", _levelfieldValuesParshed.version);
                        keValuesPairs.Add($"license_type_{_levelfieldValuesParshed.Id}", _levelfieldValuesParshed.license_type);
                        keValuesPairs.Add($"installed_machine_{_levelfieldValuesParshed.Id}", _levelfieldValuesParshed.installed_machine);
                        keValuesPairs.Add($"installation_path_{_levelfieldValuesParshed.Id}", _levelfieldValuesParshed.installation_path);
                        keValuesPairs.Add($"last_audit_date_{_levelfieldValuesParshed.Id}", _levelfieldValuesParshed.last_audit_date);
                        return _levelfield_values;
                    }
                    return null;
                }
                set
                {
                    _levelfield_values = value;
                    _levelfieldValuesParshed = null; // remove cleaned object, it will regenerated itself when opened
                }
            }
            private ExpandoObject _levelfield_values;
            public string ci_type_name { get; set; }
            public string product_name { get; set; }
            public string vendor_name { get; set; }
            public object state_name { get; set; }
            public string location_name { get; set; }
        }
    
        public class CleanLevelfield_Values
        {
            public int Id { get; set; }
            public int product { get; set; }
            public int vendor { get; set; }
            public int cost { get; set; }
            public int license_validity { get; set; }
            public DateTime installation_date { get; set; }
            public DateTime license_expiry_date { get; set; }
            public string license_key { get; set; }
            public int version { get; set; }
            public string license_type { get; set; }
            public string installed_machine { get; set; }
            public object installation_path { get; set; }
            public DateTime last_audit_date { get; set; }
        }
    
    }
 
