    public static void _ButtonProperties(List<Button> buttons){
        foreach(var button in buttons){
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
        }
    }
