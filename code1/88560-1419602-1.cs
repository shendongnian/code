    if (e.KeyCode == Keys.Down)
    {
        _currentFile--;
        if (_currentFile < 0)
        {
            _currentFile = _files.Length - 1;
        }
    }
    else if (e.KeyCode == Keys.Up)
    {
        _currentFile++;
        if (_currentFile >= _files.Length)
        {
            _currentFile = 0;
        }
    }
    
    Bitmap bmp = (Bitmap)Bitmap.FromFile(_files[_currentFile].FullName);
    if (pictureBox1.Image != null)
    {
        pictureBox1.Image.Dispose();
    }
    pictureBox1.Image = bmp;
