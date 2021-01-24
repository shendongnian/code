    public class ImagesViewModel : BaseCollectibleViewModel, ISourceImage
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        [ScriptIgnore]
        public Stream Content { get; private set; }
        public bool ShouldSerializeContent() { return false; }
        [ScriptIgnore]
        public HttpPostedFileBase File { get { ... } set { ... } }
        public bool ShouldSerializeFile() { return false; }
