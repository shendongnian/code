    # You could use user32.dll for example:
    # referenced: https://docs.microsoft.com/en-us/windows/desktop/inputdev/virtual-key-codes
    namespace Typer
    {
    
    using System;
    using System.Threading;
    
        class Program
        {
            static void Main(string[] args)
            {
                KeyboardManager.PressKey(KeyboardManager.VK_LWIN);
                KeyboardManager.PressKey(KeyboardManager.VK_R);
                Thread.Sleep(3000);
                KeyboardManager.ReleaseKey(KeyboardManager.VK_LWIN);
                KeyboardManager.ReleaseKey(KeyboardManager.VK_R);
    
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_P);
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_O);
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_W);
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_E);
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_R);
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_S);
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_H);
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_E);
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_L);
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_L);
    
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_RETURN);
                Thread.Sleep(10000);
    
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_N);
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_O);
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_T);
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_E);
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_P);
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_A);
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_D);
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_RETURN);
                Thread.Sleep(4000);
    
                KeyboardManager.PressAndReleaseKey(KeyboardManager.VK_RETURN);
    
    
    
                KeyboardManager.SayWhatIsAwesome();
            }
        }
    }
    
    
        
        
        namespace Typer
        {
            using System;
            using System.Runtime.InteropServices;
        
            public class KeyboardManager
            {
                [DllImport("user32.dll")]
                public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        
                public KeyboardManager() { }
        
                public const int VK_LWIN = 0x5B; // Left Windows Key
        
                public const int VK_RETURN = 0x0D; // Enter
                public const int VK_SPACE = 0x20; // Space
                public const int VK_A = 0x41; // A key
                public const int VK_B = 0x42; // B key
                public const int VK_C = 0x43; // C key
                public const int VK_D = 0x44; // D key
                public const int VK_E = 0x45; // E key
                public const int VK_F = 0x46; // F key
                public const int VK_G = 0x47; // G key
                public const int VK_H = 0x48; // H key
                public const int VK_I = 0x49; // I key
                public const int VK_J = 0x4A; // J key
                public const int VK_K = 0x4B; // K key
                public const int VK_L = 0x4C; // L key
                public const int VK_M = 0x4D; // M key
                public const int VK_N = 0x4E; // N key
                public const int VK_O = 0x4F; // O key
                public const int VK_P = 0x50; // P key
                public const int VK_Q = 0x51; // Q key
                public const int VK_R = 0x52; // R key
                public const int VK_S = 0x53; // S key
                public const int VK_T = 0x54; // T key
                public const int VK_U = 0x55; // U key
                public const int VK_V = 0x56; // V key
                public const int VK_W = 0x57; // W key
                public const int VK_X = 0x58; // X key
                public const int VK_Y = 0x59; // Y key
                public const int VK_Z = 0x5A; // Z key
        
        
                public const int VK_UP = 0x26; // up key
                public const int VK_DOWN = 0x28; // down key
                public const int VK_LEFT = 0x25; // left key
                public const int VK_RIGHT = 0x27; // right key
        
                public const uint KEYEVENTF_KEYUP = 0x0002;
                public const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        
                public static void SayWhatIsAwesome()
                {
                    for (int i = 0; i < 50; i++)
                    {
                        PressAndReleaseKey(VK_S);
                        PressAndReleaseKey(VK_T);
                        PressAndReleaseKey(VK_A);
                        PressAndReleaseKey(VK_C);            
                        PressAndReleaseKey(VK_K);
        
                        PressAndReleaseKey(VK_SPACE);
        
                        PressAndReleaseKey(VK_O);
                        PressAndReleaseKey(VK_V);
                        PressAndReleaseKey(VK_E);
                        PressAndReleaseKey(VK_R);
                        PressAndReleaseKey(VK_F);
                        PressAndReleaseKey(VK_L);
                        PressAndReleaseKey(VK_O);
                        PressAndReleaseKey(VK_W);
        
                        PressAndReleaseKey(VK_SPACE);
        
                        PressAndReleaseKey(VK_I);
                        PressAndReleaseKey(VK_S);
        
                        PressAndReleaseKey(VK_SPACE);
        
                        PressAndReleaseKey(VK_A);
                        PressAndReleaseKey(VK_W);
                        PressAndReleaseKey(VK_E);
                        PressAndReleaseKey(VK_S);
                        PressAndReleaseKey(VK_O);
                        PressAndReleaseKey(VK_M);
                        PressAndReleaseKey(VK_E);
        
                        PressAndReleaseKey(VK_RETURN);
                    }
                }
        
                public static void PressAndReleaseKey(int key)
                {
                    PressKey(key);
                    ReleaseKey(key);
                }
        
                public static void PressKey(int key)
                {
                    keybd_event((byte)key, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                }
        
                public static void ReleaseKey(int key)
                {
                    keybd_event((byte)key, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                }
            }
        }
