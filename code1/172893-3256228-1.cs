    class MyButton : UIButton
    {
    static MyButton FromType(UIButtonType buttonType)
    {
        var b = new MyButton (new RectangleF(0, 0, 200, 40));
        b.SetTitle("My Button",UIControlState.Normal);
        //additional customization here
    
        return b;
        }
    }
