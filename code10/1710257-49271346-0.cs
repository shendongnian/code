    class Program
        {
            static void Main(string[] args)
            {
                List<Resources> resources = new List<Resources>();
                resources.Add(new Resources { Resource = "R1", ResourceGroup = "RG1", ResourceType = "RT1" });
                resources.Add(new Resources { Resource = "R2", ResourceGroup = "RG1", ResourceType = "RT1" });
                resources.Add(new Resources { Resource = "R3", ResourceGroup = "RG3", ResourceType = "RT2" });
                String resource = String.Join(",", resources.Select(x => x.Resource).Distinct());
            }
        }
    
        class Resources
        {
            public string Resource { get; set; }
            public string ResourceGroup { get; set; }
            public string ResourceType { get; set; }
        }
