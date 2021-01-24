    Bitmap bmp= new Bitmap(controls.Width, controls.Height-50, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    Graphics Grap = Graphics.FromImage(bmp);
    Grap.CopyFromScreen(PointToScreen(controls.Location).X, PointToScreen(controls.Location).Y, 0, 0, AnhDoThi.Size, CopyPixelOperation.SourceCopy);
    SaveFileDialog save = new SaveFileDialog();
    save.Filter = "JPEG|*.jpg";
    DialogResult tl = save.ShowDialog();
    if (tl == DialogResult.OK)
    {
        bmp.Save(save.FileName);
        MessageBox.Show("Completed !");
    }
