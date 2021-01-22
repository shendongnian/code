    public void F(object sender, MouseEventArgs e) {}; 
    public MyLeftClickHandler l;
    public MyRightClickHandler r;
    public void Test()
    {
        l = F;  // Automatically converted.
        r = F;  // Automatically converted to a different type.
        l = r;  // Syntax error.  Incompatible types.
        l = new MyLeftClickHandler(r);  // Explicit conversion works.
    }
