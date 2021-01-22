    public void ChangeColor(ref int color)
    {
        color += 5;
    }
    void SomeMethod()
    {
        ChangeColor(ref thisColor.R); //Change the red value
        ChangeColor(ref thisColor.B); //Change the blue value
    }
