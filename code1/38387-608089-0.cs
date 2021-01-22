...
delegate void InvocadorMetodos();
...
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
                {
                    InvocadorMetodos invalida = Invalidar;
                    this.Invoke(invalida);
                }
                else
                    this.Invalidar();
            }
        }
