    private void Form1_Load(object sender, System.EventArgs e)
    {
      Stream fontStream = this.GetType().Assembly.GetManifestResourceStream("embedfont.Alphd___.ttf");
 
      byte[] fontdata = new byte[fontStream.Length];
      fontStream.Read(fontdata,0,(int)fontStream.Length);
      fontStream.Close();
      unsafe
      {
        fixed(byte * pFontData = fontdata)
        {
          pfc.AddMemoryFont((System.IntPtr)pFontData,fontdata.Length);
        }
      }
    }
