    public static void SetButtonProperties(List<Button> buttons){
        foreach(var button in buttons){
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
        }
    }
