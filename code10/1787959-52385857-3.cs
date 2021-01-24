    public static class ButtonProperties
    {
        public static void _ButtonProperties(params Button[] buttons)
        {
            foreach (Button b in buttons)
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
            }
        }
    }
