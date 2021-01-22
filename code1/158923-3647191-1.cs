    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace UnimatrixOne
    {
      public class RichTextBoxHelper
      {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out, MarshalAs(UnmanagedType.LPStruct)] CHARFORMATA lParam);
        private const long CFM_SIZE = 0x80000000;
        private const int EM_GETCHARFORMAT = 0x043A;
        private const int SCF_SELECTION = 0x01;
        /// <summary> 
        /// Contains information about character formatting in a rich edit control. 
        /// </summary> 
        /// <remarks><see cref="CHARFORMAT"/>works with all Rich Edit versions.</remarks> 
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public class CHARFORMATA
        {
          public int cbSize = Marshal.SizeOf(typeof(CHARFORMATA));
          public int dwMask;
          public int dwEffects;
          public int yHeight;
          public int yOffset;
          public int crTextColor;
          public byte bCharSet;
          public byte bPitchAndFamily;
          [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
          public byte[] szFaceName = new byte[32];
        }
        /// <summary> 
        /// Gets or sets the underline size off the current selection. 
        /// </summary>
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static float? GetSelectionSize(RichTextBox control)
        {
          var lParam = new CHARFORMATA();
          lParam.cbSize = Marshal.SizeOf(lParam);
          // Get the underline style 
          SendMessage(new HandleRef(control, control.Handle), EM_GETCHARFORMAT, SCF_SELECTION, lParam);
          if ((lParam.dwMask & -CFM_SIZE) != 0)
          {
            float emSize = ((float)lParam.yHeight) / 20f;
            if ((emSize == 0f) && (lParam.yHeight > 0))
              emSize = 1f;
            return emSize;
          }
          else
            return null;
        }
      }
    }
