    public class Label
    {
        public string Group { get; set; }
        public string Text { get; set; }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Group))
            {
                return Text ?? string.Empty;
            }
            return $"{Group ?? string.Empty} = {Text ?? string.Empty}";
        }
    }
    public class LabelGroup
    {
        private readonly List<Label> _labels;
        public LabelGroup(List<Label> labels)
        {
            _labels = labels ?? throw new ArgumentNullException(nameof(labels));
        }
        /// <inheritdoc />
        public override string ToString()
        {
            if (_labels.Any())
            {
                return string.Join(", ", _labels);
            }
            return string.Empty;
        }
    }
