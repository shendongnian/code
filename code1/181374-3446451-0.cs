    private List<Label> CreateLabels(params string[] names)
    {
            List<Label> result = new List<Label>();
            foreach(string name in names)
            {
                    Label label = new Label()
                    label.ID = 0;
                    label.Name = name;
                    result.Add(label);
            }
            result;
    }
