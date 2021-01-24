    public partial class RootObject {
        [JsonProperty("content")]
        public Content[] Content { get; set; }
    }
    public partial class Content {
        [JsonProperty("solverSolution")]
        public SolverSolution SolverSolution { get; set; }
    }
    public partial class SolverSolution {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("maxHeight")]
        public double MaxHeight { get; set; }
        [JsonProperty("layers")]
        public long Layers { get; set; }
        [JsonProperty("solution")]
        public Solution[] Solution { get; set; }
        [JsonProperty("default")]
        public bool Default { get; set; }
    }
    public partial class Solution {
        [JsonProperty("X1")]
        public long X1 { get; set; }
        [JsonProperty("Y1")]
        public long Y1 { get; set; }
        [JsonProperty("Z1")]
        public long Z1 { get; set; }
        [JsonProperty("X2")]
        public long X2 { get; set; }
        [JsonProperty("Y2")]
        public long Y2 { get; set; }
        [JsonProperty("Z2")]
        public long Z2 { get; set; }
    }
