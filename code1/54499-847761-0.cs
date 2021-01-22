    var location = new System.Drawing.Point();
    location.X = (int)Left;
    location.Y = (int)Top;
    Properties.Settings.Default.Location = location;
            
    var size = new System.Drawing.Size();
    size.Width = (int)Width;
    size.Height = (int)Height;
    Properties.Settings.Default.Size = size;
    Properties.Settings.Default.Save();
