    private void button1_Click(object sender, EventArgs e)
    {
        Metafile emf = null;
        using (var ms = new MemoryStream(Properties.Resources.blank))
        {
            emf = new Metafile(ms);
        }
        IntPtr h = emf.GetHenhmetafile();
        uint size = GetEnhMetaFileBits(h, 0, null);
        byte[] data = new byte[size];
        GetEnhMetaFileBits(h, size, data);
        using (FileStream w = File.
            Create("C:\\Users\\chrisd\\Documents\\emfbitmap1.emf"))
        {
            w.Write(data, 0, (int)size);
        }
        DeleteEnhMetaFile(h);
    }
