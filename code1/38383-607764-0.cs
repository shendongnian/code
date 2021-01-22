    public Image Imagen
    {
        get { get return imagen; }
        set {
            imagen = value;
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(this.Invalidate));
            else
                this.Invalidate();
        }
    }
