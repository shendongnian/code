    public bool IsOnScreen(Form form) 
    {
       // Create rectangle
       Rectangle formRectangle = new Rectangle(form.Left, form.Top, form.Width, form.Height); 
        
       // Test
       return Screen.AllScreens.Any(s => s.WorkingArea.IntersectsWith(formRectangle));
    }
