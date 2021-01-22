    class MyButton : UIButton
    {
    static UIButton FromType(UIButtonType buttonType)
    {
        var b = UIButton.FromType(buttonType);
    
        //additional customization here
    
        return b;
        }
    }
