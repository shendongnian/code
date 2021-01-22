    using System;
    using System.Runtime.InteropServices;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();
        static void Main(string[] args)
        {
            string sourceImagePath = args[0];
            string destinationImagePath = args[1];
            int desiredWidth = int.Parse(args[2]);
            int desiredHeight = int.Parse(args[3]);
            GraphicsDevice graphicsDevice = new GraphicsDevice(
                GraphicsAdapter.DefaultAdapter,
                DeviceType.Hardware,
                GetConsoleWindow(),
                new PresentationParameters());
            SpriteBatch batch = new SpriteBatch(graphicsDevice);
            Texture2D sourceImage = Texture2D.FromFile(
                graphicsDevice, sourceImagePath);
         
            RenderTarget2D renderTarget = new RenderTarget2D(
                graphicsDevice, 
                desiredWidth, desiredHeight, 1, 
                SurfaceFormat.Color);
            
            Rectangle destinationRectangle = new Rectangle(
                0, 0, desiredWidth, desiredHeight);
            graphicsDevice.SetRenderTarget(0, renderTarget);
            batch.Begin();
            batch.Draw(sourceImage, destinationRectangle, Color.White);
            batch.End();
            graphicsDevice.SetRenderTarget(0, null);
            Texture2D scaledImage = renderTarget.GetTexture();
            scaledImage.Save(destinationImagePath, ImageFileFormat.Png);
        }
    }
