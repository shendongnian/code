            float size = 5;
            for (int ix = 0; ix < 10; ++ix) {
                var font = new Font("Calibri", size, FontStyle.Regular);
                string txt = new string('0', 100);
                SizeF sz1 = TextRenderer.MeasureText("00", font) - TextRenderer.MeasureText("0", font);
                Console.WriteLine("{0} {1:N3}", size, sz1.Width);
                size += 2;
            }
