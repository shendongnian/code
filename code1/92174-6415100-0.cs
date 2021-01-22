    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Drawing;
    using System.Drawing.Imaging;
    
    
    namespace ConsoleApplication1
    {
    
        public class ScreenRecorder
        {
    
            private static string tempDir = Path.GetTempPath() + "/snapshot/";
            private static System.Threading.Thread snap = new System.Threading.Thread(Snapshot);
    
            private static System.Drawing.Rectangle _Bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            public static System.Drawing.Rectangle Bounds
            {
                get { return _Bounds; }
                set { _Bounds = value; }
            }
    
            private static void Snapshot()
            {
                if (!Directory.Exists(tempDir))
                    Directory.CreateDirectory(tempDir);
                int Co = 0;
                do
                {
                    Co += 1;
                    System.Threading.Thread.Sleep(50);
                    System.Drawing.Bitmap X = new System.Drawing.Bitmap(_Bounds.Width, _Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    using(System.Drawing.Graphics G = System.Drawing.Graphics.FromImage(X)) {
                        G.CopyFromScreen(_Bounds.Location, new System.Drawing.Point(), _Bounds.Size);
                        System.Drawing.Rectangle CurBounds = new System.Drawing.Rectangle(System.Drawing.Point.Subtract(System.Windows.Forms.Cursor.Position,Bounds.Size), System.Windows.Forms.Cursor.Current.Size);
                        System.Windows.Forms.Cursors.Default.Draw(G, CurBounds);
                   }
                    System.IO.FileStream FS = new System.IO.FileStream(tempDir + FormatString(Co.ToString(), 5, '0') + ".png", System.IO.FileMode.OpenOrCreate);
                    X.Save(FS, System.Drawing.Imaging.ImageFormat.Png);
                    X.Dispose();
                    FS.Close();
                } while (true);
            }
    
            public static void ClearRecording()
            {
                if (Directory.Exists(tempDir))
                    Directory.Delete(tempDir, true);
                    Directory.CreateDirectory(tempDir);
            }
    
            public static void Save(string Output)
            {
                System.Windows.Media.Imaging.GifBitmapEncoder G = new System.Windows.Media.Imaging.GifBitmapEncoder();
    
                List<System.IO.FileStream> X = new List<System.IO.FileStream>();
                foreach (string Fi in Directory.GetFiles(tempDir, "*.png", SearchOption.TopDirectoryOnly))
                {
                    System.IO.FileStream TempStream = new System.IO.FileStream(Fi, System.IO.FileMode.Open);
                    System.Windows.Media.Imaging.BitmapFrame Frame = System.Windows.Media.Imaging.BitmapFrame.Create(TempStream);
                    X.Add(TempStream);
                    G.Frames.Add(Frame);
                }
                System.IO.FileStream FS = new System.IO.FileStream(Output, System.IO.FileMode.OpenOrCreate);
                G.Save(FS);
                FS.Close();
    
                foreach (System.IO.FileStream St in X)
                {
                    St.Close();
    
                }
    
            }
    
            public static void Start()
            {
                snap = new System.Threading.Thread(Snapshot);
                snap.Start();
            }
    
            public static void Stop()
            {
                snap.Abort();
            }
    
            private static string FormatString(string S, int places, char character)
            {
                if (S.Length >= places)
                    return S;
                for (int X = S.Length; X <= places; X++)
                {
                    S = character + S;
                }
                return S;
            }
    
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                ScreenRecorder.Start();
                System.Threading.Thread.Sleep(5000);
                ScreenRecorder.Stop();
                ScreenRecorder.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\video.gif");
                ScreenRecorder.ClearRecording();
            }
        }
    }
