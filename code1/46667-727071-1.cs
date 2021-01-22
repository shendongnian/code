    public void LoadMyFontLolKThx()
    {
        // get our font and wrap it in a memory stream
        byte[] myFont = Properties.Resources.MyFontLol;
        using (var ms = new MemoryStream(myFont))
        {
            // used to store our font and make it available in our app
            PrivateFontCollection pfc = new PrivateFontCollection();
            // The next call requires a pointer to our memory font
            // I'm doing it this way; not sure what best practice is
            GCHandle handle = GCHandle.Alloc(ms, GCHandleType.Pinned);
            // If Length > int.MaxValue this will throw
            checked
            {
                pfc.AddMemoryFont(
                    handle.AddrOfPinnedObject(), (int)ms.Length); 
            }
            var font = new Font(pfc.Families[0],12);
            
            // use your font here
        }
    }
