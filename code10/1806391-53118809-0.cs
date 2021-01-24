    class VideoDescriptionViewModel
    {
        public string Description { get; private set; }
        public int Index { get; private set; }
    
        public VideoDescriptionViewModel(string description, int index)
        {
            Description = description;
            Index = index;
        }
    }
