        public Image GetImage(string name)
        {
            switch (name)
            {
                case "PictureBox1":
                    return Properties.Resources.Picture1;
                case "PictureBox2":
                    return Properties.Resources.Picture2;
                default:
                    return null;
            }
        }
