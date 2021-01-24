    public static void _ButtonProperties(List<Button> buttons)
    {
        foreach (var button in buttons)
        {
             button.FlatAppearance.BorderSize = 0;
             button.FlatStyle = FlatStyle.Flat;
        }
    }
