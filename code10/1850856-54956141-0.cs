     /// <summary>
        /// 
        /// </summary>
        /// <param name="promotionImgPath"></param>
        /// <param name="codeImgPath"></param>
        /// <returns></returns>
        public static System.Drawing.Image CombinImage(string promotionImgPath, string codeImgPath)
        {
            System.Drawing.Image promotionImg = System.Drawing.Image.FromFile(promotionImgPath);     //promotion Img
            System.Drawing.Image code = System.Drawing.Image.FromFile(codeImgPath);        // code Img
            System.Drawing.Graphics g = Graphics.FromImage(promotionImg);
            float codeWidth = 175;
            float codeHeight = 162;
            //in order to make code img to center;
            float xPosition =(promotionImg.Width / 2) - (codeWidth / 2);
            float yPosition = 14;
            g.DrawImage(code, xPosition, yPosition, codeHeight, 162);
            GC.Collect();
            return promotionImg;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageIn"></param>
        /// <returns></returns>
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
