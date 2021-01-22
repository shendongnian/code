    class ExtensionMethods
    {
        public static Vector2 GetViewSize(this GraphicsDevice device)
        {
            return new Vector2(device.Viewport.Width, device.Viewport.Height);
        }
    }
