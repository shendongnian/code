            Byte[,,] color = new Byte[256, 1, 3];
            int i = 0;
            for (double x = 0; x < palette.Rows;)
            {
                color[i, 0, 0] = palette.Data[(int)x, palette.Width / 2, 0];
                color[i, 0, 1] = palette.Data[(int)x, palette.Width / 2, 1];
                color[i, 0, 2] = palette.Data[(int)x, palette.Width / 2, 2];
                i++;
                x = x + 3.109;
            }
            Mat lut = new Mat(256, 1, DepthType.Cv8U, 3);
            lut.SetTo(color);
