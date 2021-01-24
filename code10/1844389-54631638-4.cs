    private void Start()
    {
        var buttons = FindObjectsOfType<Example>();
        foreach(var button in buttons)
        {
            // it is allways save to remove listeners even if
            // they are not there yet
            // this makes sure that they are only added once
            button.OnHover.RemoveListener(OnButtonHovered);
            button.OnHover.AddListener(OnButtonHovered);
        }
    }
    private void OnButtonHovered(string buttonName)
    {
        // do something with the buttonName
    }
