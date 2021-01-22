    public static void Draw(this IImage image)
    {
       var method = image.GetType().GetMethod("Draw");
       if(method != null)
       {
          method.Invoke(image,null);
       }
    }
