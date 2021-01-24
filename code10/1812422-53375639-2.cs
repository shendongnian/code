    private void btnFeature_Click(object sender, EventArgs e)
        {
            if (pca == null)
            {
                MessageBox.Show("Please compute the analysis first!");
                return;
            }
            ImageToArray converter = new ImageToArray(min: 0, max: 1);
            int rows = dataGridView3.Rows.Count;
            double[][] inputs = new double[rows][];
            double[][] features = new double[rows][];
            int[] outputs = new int[rows];
            int index = 0;
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                Bitmap image = row.Cells["colFace2"].Value as Bitmap;
                int label = (int)row.Cells["colLabel2"].Value;
                double[] input;
                converter.Convert(image, out input);
                double[] feature = pca.Transform(input);
                row.Cells["colProjection"].Value = string.Join("\t", feature.Select(f => Math.Abs(f / 30).ToString("N3")));
                TextWriter writer = new StreamWriter(@"C:\Users\LENOVO\Desktop\OKE.txt");
                for (int i = 0; i < dataGridView3.RowCount; i++)
                {
                    writer.Write(row.Cells["colProjection"].Value + "\t"); 
                }
                writer.WriteLine("");
                writer.Close();
                row.Tag = feature;
                inputs[index] = input;
                features[index] = feature;
                outputs[index] = label;
                index++;
            }
        }
