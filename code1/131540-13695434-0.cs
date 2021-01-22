    public event EventHandler ButtonClicked
    {
       add { btnUpload.Click += value; }
       remove { btnUpload.Click -= value; }
    }
