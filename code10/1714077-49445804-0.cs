    using System.Drawing;
    using System.Drawing.Drawing2D;
    using Telegram.Bot;
    using Telegram.Bot.Args;
    using System.IO;
    using System.Drawing.Imaging;
    
    namespace LoadGraphicsFromMemory
    {
        public static class ImageExtensions
        {
            public static MemoryStream ToMemoryStream(this Bitmap image, ImageFormat format)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, format);
                    return ms;
                }
            }
    
        }
    
        class Program
        {
            private static float efficienza_int;
            private static readonly TelegramBotClient Bot = new TelegramBotClient("Your API key");
    
            static void Main(string[] args)
            {
                
    
                Bot.OnMessage += BotOnMessageReceived;
            }
    
            private static void BotOnMessageReceived(object sender, MessageEventArgs e)
            {
                Bitmap speedometer = new Bitmap(@"C:\Immagini\bot\speedometer.png");
                Bitmap pointer = new Bitmap(@"C:\Immagini\bot\pointer.png");
                Bitmap finalImage = new Bitmap(speedometer);
                using (Graphics graphics = Graphics.FromImage(finalImage))
                {
                    Bitmap rotatedPointer = RotateImage(pointer, efficienza_int * (float)1.8);
                    rotatedPointer.MakeTransparent(Color.White);
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.DrawImage(rotatedPointer, 0, 0);
    
                }
    
                Bot.SendPhotoAsync(e.Message.Chat.Id, new Telegram.Bot.Types.FileToSend("My File", finalImage.ToMemoryStream(ImageFormat.Jpeg)));
            }
    
            private static Bitmap RotateImage(Bitmap pointer, object p)
            {
                return pointer;
            }
    
           
        }
    }
