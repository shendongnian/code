    public class Label
    {
        public string Group { get; set; }
        public string Text { get; set; }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Group))
            {
                return Text;
            }
            return string.Format("{0} = {1}", Group ?? string.Empty, Text ?? string.Empty);
        }
    }
    public class LabelGroup
    {
        private readonly List<Label> _labels;
        public LabelGroup(List<Label> labels)
        {
            if (labels == null)
            {
                throw new ArgumentNullException("labels");
            }
            _labels = labels;
        }
        public override string ToString()
        {
            if (_labels.Any())
            {
                return string.Join(", ", _labels.Select(x => x.ToString()).ToArray());
            }
            return string.Empty;
        }
    }
