     protected override void Initialize()
        {
            sprite = Content.Load<Texture2D>("Parado");
            Color[] data = new Color[sprite.Width * sprite.Height];
            sprite.GetData(data);
            // new color
            Color novaCor =Color.Blue;
            
            for (int i = 0; i < data.Length; i++)
            {
                // cor roxa no desenho
                if (data[i].R == 142
                    && data[i].G == 24
                    && data[i].B == 115)
                {
                    data[i] = novaCor;
                }
            }
            sprite.SetData<Color>(data);
            posicaoNinja = new Vector2(0, 200);
            base.Initialize();
        }
