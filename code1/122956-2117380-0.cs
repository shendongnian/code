        private void Form1_Load(object sender, EventArgs e)
        {
            var list = WindowsFormsApplication1.Properties.Resources.ResourceManager.GetResourceSet(new System.Globalization.CultureInfo("en-us"), true, true);
            foreach (System.Collections.DictionaryEntry img in list)
            {
                System.Diagnostics.Debug.WriteLine(img.Key);
                //use img.Value to get the bitmap
            }
        }
