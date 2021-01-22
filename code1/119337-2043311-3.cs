        private void button1_Click(object sender, EventArgs e)
        {
            int thumbSize = 32;
            Dictionary<Color, int> colors = new Dictionary<Color, int>();
            Bitmap thumbBmp = new Bitmap(pictureBox1.Image.GetThumbnailImage(
                thumbSize, thumbSize, ThumbnailCallback, IntPtr.Zero));
            
            //just for test
            pictureBox2.Image = thumbBmp;            
            
            for (int i = 0; i < thumbSize; i++)
            {
                for (int j = 0; j < thumbSize; j++)
                {
                    Color col = thumbBmp.GetPixel(i, j);
                    if (colors.ContainsKey(col))
                        colors[col]++;
                    else
                        colors.Add(col, 1);
                }                
            }
            List<KeyValuePair<Color, int>> keyValueList = 
                new List<KeyValuePair<Color, int>>(colors);
            keyValueList.Sort(
                delegate(KeyValuePair<Color, int> firstPair,
                KeyValuePair<Color, int> nextPair)
                {
                    return nextPair.Value.CompareTo(firstPair.Value);
                });
            List<string> colorNames = new List<string>();
            List<Color> colorTop = new List<Color>();
            foreach (KeyValuePair<Color, int> intColorPair in keyValueList)
            {
                colorNames.Add(intColorPair.Key.ToString());
                colorTop.Add(intColorPair.Key);
            }
            string top10Colors = "";
            for (int i = 0; i < 10; i++)
			{			 
                top10Colors += "\n" + i + ". " + colorNames[i];
                flowLayoutPanel1.Controls[i].BackColor = colorTop[i];
			}
            MessageBox.Show("Top 10 Colors: " + top10Colors);
        }
        public bool ThumbnailCallback() { return false; }
