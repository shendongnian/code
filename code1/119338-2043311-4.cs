        private void button1_Click(object sender, EventArgs e)
        {
            int thumbSize = 32;
            Dictionary<Color, int> colors = new Dictionary<Color, int>();
            Bitmap thumbBmp = 
                new Bitmap(pictureBox1.BackgroundImage.GetThumbnailImage(
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
            string top10Colors = "";
            for (int i = 0; i < 10; i++)
			{
                top10Colors += string.Format("\n {0}. {1} > {2}",
                    i, keyValueList[i].Key.ToString(), keyValueList[i].Value);
                flowLayoutPanel1.Controls[i].BackColor = keyValueList[i].Key;
			}
            MessageBox.Show("Top 10 Colors: " + top10Colors);
        }
        public bool ThumbnailCallback() { return false; }
