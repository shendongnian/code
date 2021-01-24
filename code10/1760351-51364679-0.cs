    public static PropertyItem GetDateTakenFromImage(Image image)
        {
            try
            {
                return image.GetPropertyItem(36867);
            }
            catch
            {
                return null;
            }
        }
