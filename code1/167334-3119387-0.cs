    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Runtime.InteropServices;
    using System.Drawing.Imaging;
    using System.Collections;
    using System.Runtime.InteropServices.ComTypes;
    using System.Globalization;
    using System.Reflection;
    
    namespace ScreenShotTest
    {
        class Program
        {
            [STAThreadAttribute()]
            static void Main(string[] args)
            {
                Utilities.IO.FTPFactory ftp = new Utilities.IO.FTPFactory();
                ftp.Debug = true;
                ftp.RemoteHost = "[host]";
                ftp.login();
    
                DateTime s = DateTime.Now;
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine("Friggin Test Start!");
                
                DA_ScreenShot.ScreenCamera camera = new DA_ScreenShot.ScreenCamera(15);
                while(true)
                {
                    camera.CaptureToJpg(@"c:\tmp.jpg");
                    Console.WriteLine(String.Format(@"Snapping @ {0}",DateTime.Now.ToString()));
    
                    System.IO.FileInfo fi = new System.IO.FileInfo(@"c:\tmp.jpg");
    
                    while(!fi.Exists)
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
    
                    try
                    {
                        ftp.upload(@"c:\tmp.jpg");
                        ftp.deleteRemoteFile("FileShot.jpg");
                        ftp.renameRemoteFile(@"tmp.jpg",@"FileShot.jpg");
                        fi.Delete();
                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
    
                    System.Threading.Thread.Sleep(5000);
                }
    
                ftp.close();
    
                TimeSpan ts = DateTime.Now - s;
                Console.WriteLine("Finished in " + ts.TotalMilliseconds.ToString() + " ms");
    
                camera.releaseMem();
                Console.WriteLine("Friggin Test Stop!");
    
            }
        }
    }
    
    namespace DA_ScreenShot
    {
    	/// <summary>
    	/// Captures a screenshot to a local file using the System.Drawing GDI+ hooks.
    	/// </summary>
    	public class ScreenCamera
    	{
    		private System.Drawing.Size display;
    		private System.Drawing.Bitmap bitmap;
    		private System.Drawing.Graphics graphics;
    
            private ImageCodecInfo encInfo;
            private EncoderParameters encParams;
            private EncoderParameter encParam;
            private Rectangle rect;
    		
    		public ScreenCamera(long quality)
    		{
    			SetupGDIObjects();
    
                UpdateSize();
    
                encInfo = GetEncoderInfo("image/jpeg");
                System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;
    
    		    encParams = new EncoderParameters(1);
    	        encParam = new EncoderParameter(encoder,quality);
                encParams.Param[0] = encParam;
                rect = new Rectangle(0,0,display.Width,display.Height);
    		}
    		
    		/// <summary>
    		/// Sets up the objects that ScreenCamera needs to work.
    		/// </summary>
    		/// <returns>Successfully setup?</returns>
    		private bool SetupGDIObjects()
    		{
    			try
    			{
    			display = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
    			bitmap = new Bitmap(display.Width, display.Height);
    			graphics = System.Drawing.Graphics.FromImage(bitmap);
    			}
    			catch (Exception ex)
    			{
    				MessageBox.Show(ex.Message);
    				return false;
    			}
    			return true;
    		}
    		
    		/// <summary>
    		/// Checks to see if the display size has changed and calls SetupGDIObjects
    		/// if it has.
    		/// </summary>
    		/// <returns>Update Successful?</returns>
    		private bool UpdateSize()
    		{
    			if (this.display.Height == Screen.PrimaryScreen.Bounds.Height &&
    			    this.display.Width == Screen.PrimaryScreen.Bounds.Width)
    			{
    				return true;
    			}
    			else
    			{
    				return SetupGDIObjects();
    			}
    		}
    		
    		/// <summary>
    		/// Method to capture a screenshot to a local file using the System.Drawing GDI+ hooks.
    		/// </summary>
    		/// <param name="strFileName">The destination file to save the image to.</param>
    		/// <returns>Successful?</returns>
    		public bool CaptureToJpg(string strFileName)
    		{
    			try
    			{
    				
    				graphics.CopyFromScreen(0,0,0,0, display);
    				bitmap.Save(strFileName, encInfo, encParams);
    			}
    			catch (Exception e)
    			{
    				MessageBox.Show(e.ToString(), "Error!");
    				return false;
    			}
    			return true;	
    		}
    
    		public void releaseMem()
    		{
    			//display = null;
    			graphics.Dispose();
    			graphics = null;
    			bitmap.Dispose();
    			bitmap = null;
    		}
    
    		private static ImageCodecInfo GetEncoderInfo(String mimeType)
    		{
    			int j;
    			ImageCodecInfo[] encoders;
    			encoders = ImageCodecInfo.GetImageEncoders();
    			for(j = 0; j < encoders.Length; ++j)
    			{
    				if(encoders[j].MimeType == mimeType)
    					return encoders[j];
    			}
    			return null;
    		}
    
    	}
    
        public static class ScreenShot
        {
            public static void CaptureAndSave(string fileName)
            {
                uint intReturn = 0;
                NativeWIN32.INPUT structInput;
                structInput = new NativeWIN32.INPUT();
                structInput.type = (uint)1;
                structInput.ki.wScan = 0;
                structInput.ki.time = 0;
                structInput.ki.dwFlags = 0;
                structInput.ki.dwExtraInfo = 0;
                
                //Press Alt Key
                structInput.ki.wVk = (ushort)NativeWIN32.VK.MENU;
                intReturn = NativeWIN32.SendInput((uint)1, ref structInput, Marshal.SizeOf(structInput));
                
                // Key down the actual key-code
                structInput.ki.wVk = (ushort)NativeWIN32.VK.SNAPSHOT;//vk;
                intReturn = NativeWIN32.SendInput((uint)1, ref structInput, Marshal.SizeOf(structInput));
    
                
                // Key up the actual key-code
                structInput.ki.dwFlags = NativeWIN32.KEYEVENTF_KEYUP;
                structInput.ki.wVk = (ushort)NativeWIN32.VK.SNAPSHOT;//vk;
                intReturn = NativeWIN32.SendInput((uint)1, ref structInput, Marshal.SizeOf(structInput));
    
                //Keyup Alt
                structInput.ki.dwFlags = NativeWIN32.KEYEVENTF_KEYUP;
                structInput.ki.wVk = (ushort)NativeWIN32.VK.MENU;
                intReturn = NativeWIN32.SendInput((uint)1, ref structInput, Marshal.SizeOf(structInput));
                
                try
                {
                    if(Clipboard.ContainsImage())
                    {
                        Object data = Clipboard.GetData(DataFormats.Bitmap);;
                        Clipboard.Clear();
    
                        if (data != null)
                        {
                            Image image = (Image)data;
                            image.Save(fileName,System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                    }
                }catch(Exception ex){Console.WriteLine(ex.Message);}
            }
        }
    
        internal class NativeWIN32
        {
            public const ushort KEYEVENTF_KEYUP = 0x0002;
    
            public enum VK : ushort
            {
                SHIFT                = 0x10,
                CONTROL              = 0x11,
                MENU                 = 0x12,
                ESCAPE               = 0x1B,
                BACK                 = 0x08,
                TAB                  = 0x09,
                RETURN               = 0x0D,
                PRIOR                = 0x21,
                NEXT                 = 0x22,
                END                  = 0x23,
                HOME                 = 0x24,
                LEFT                 = 0x25,
                UP                   = 0x26,
                RIGHT                = 0x27,
                DOWN                 = 0x28,
                SELECT               = 0x29,
                PRINT                = 0x2A,
                EXECUTE              = 0x2B,
                SNAPSHOT             = 0x2C,
                INSERT               = 0x2D,
                DELETE               = 0x2E,
                HELP                 = 0x2F,
                NUMPAD0              = 0x60,
                NUMPAD1              = 0x61,
                NUMPAD2              = 0x62,
                NUMPAD3              = 0x63,
                NUMPAD4              = 0x64,
                NUMPAD5              = 0x65,
                NUMPAD6              = 0x66,
                NUMPAD7              = 0x67,
                NUMPAD8              = 0x68,
                NUMPAD9              = 0x69,
                MULTIPLY             = 0x6A,
                ADD                  = 0x6B,
                SEPARATOR            = 0x6C,
                SUBTRACT             = 0x6D,
                DECIMAL              = 0x6E,
                DIVIDE               = 0x6F,
                F1                   = 0x70,
                F2                   = 0x71,
                F3                   = 0x72,
                F4                   = 0x73,
                F5                   = 0x74,
                F6                   = 0x75,
                F7                   = 0x76,
                F8                   = 0x77,
                F9                   = 0x78,
                F10                  = 0x79,
                F11                  = 0x7A,
                F12                  = 0x7B,
                OEM_1                = 0xBA,   // ',:' for US
                OEM_PLUS             = 0xBB,   // '+' any country
                OEM_COMMA            = 0xBC,   // ',' any country
                OEM_MINUS            = 0xBD,   // '-' any country
                OEM_PERIOD           = 0xBE,   // '.' any country
                OEM_2                = 0xBF,   // '/?' for US
                OEM_3                = 0xC0,   // '`~' for US
                MEDIA_NEXT_TRACK     = 0xB0,
                MEDIA_PREV_TRACK     = 0xB1,
                MEDIA_STOP           = 0xB2,
                MEDIA_PLAY_PAUSE     = 0xB3,
                LWIN                 = 0x5B,
                RWIN                 = 0x5C
            }
    
            public struct KEYBDINPUT
            {
                public ushort wVk;
                public ushort wScan;
                public uint dwFlags;
                public long time;
                public uint dwExtraInfo;
            }
    
            [StructLayout(LayoutKind.Explicit,Size=28)]
            public struct INPUT
            {
                [FieldOffset(0)] public uint type;
                [FieldOffset(4)] public KEYBDINPUT ki;
            }
    
            [DllImport("user32.dll")]
            public static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);
        }
    }
