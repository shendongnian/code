    public void blah()
    {
       using( var o = new OpenFileDialog())
       {
            if(o.ShowDialog() == DialogResult.OK)
            {
                 Image i = new Image();
                 i.Source = new BitmapImage(o.FileName);
                 //p.AutoSize = SizeMode.AutoSize; <= not sure about this part.
                 this.Children.Add(i);
            }
       }
    }
