    public abstract partial class ClientTreeNode {
        [JsonProperty]
        public int ID { get;  private set; }
        [JsonProperty]
        public string Question { get;  private set; }
        [JsonProperty]
        public List<ClientTreeNode> Children { get;  private set; }
        [JsonProperty]
        public QuestionCategories Category { get;  private set; }
        [JsonProperty]
        public Dictionary<object, int[]> AnswerNodes { get;  private set; }
    }
