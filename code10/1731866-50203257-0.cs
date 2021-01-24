    using Newtonsoft.Json;
    public class ImagesViewModel : BaseCollectibleViewModel, ISourceImage
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        [ScriptIgnore]
        [JsonIgnore]
        public Stream Content { get; private set; }
        [ScriptIgnore]
        [JsonIgnore]
        public HttpPostedFileBase File { get { ... } set { ... } }
