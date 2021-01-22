    public Image Imagen
    {
        get
        {
            return imagen;
        }
        set
        {
            imagen = value;
            if (this.InvokeRequired)
                this.Invoke(new Action(this.Invalidate));
            else
                this.Invalidate();
        }
    }
