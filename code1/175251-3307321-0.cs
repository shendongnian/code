    PropertyInfo pInfo = pictureBox1.GetType().GetProperty("ImageRectangle", 
        System.Reflection.BindingFlags.Public | 
        System.Reflection.BindingFlags.NonPublic | 
        System.Reflection.BindingFlags.Instance);
    Rectangle rectangle = (Rectangle)pInfo.GetValue(pictureBox1, null);
