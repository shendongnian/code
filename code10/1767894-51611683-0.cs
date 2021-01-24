    var newline = line;
                var size = TextRenderer.MeasureText(newline, new Font("Microsoft Sans Serif", 7.8f));
                var width = size.Width;
                int spacestoadd = 0;
                while(max-10 > width)
                {
                    newline = " " + newline;
                     size = TextRenderer.MeasureText(newline, new Font("Microsoft Sans Serif", 7.8f));
                     width = size.Width;
                    spacestoadd++;
                }
                dataGridView1.Rows.Add(newline, spacestoadd);
