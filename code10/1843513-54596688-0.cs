            using (Graphics gr = Graphics.FromImage(selected_img))
            {
                int y = -50;
                int opacity = 127; // 0 to 255
                string txt = "watermark";
                int x = selected_img.Width;
                GraphicsState state = gr.Save();
                gr.ResetTransform();
                gr.TranslateTransform(selected_img.Width / 2, selected_img.Height / 2);
                gr.RotateTransform(45);
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                using (Font font = new Font("Arial", 14.0f))
                {
                    SizeF textSize = gr.MeasureString(txt, font);
                    using (Brush brush = new SolidBrush(Color.FromArgb(opacity, Color.DarkGray)))
                    {
                        for (int b = 1; b <= 5; b++, y += 25)
                        {
                            gr.DrawString(txt, font, brush, new PointF(-(textSize.Width / 2), y));
                        }
                    }
                }
                gr.Restore(state);
            }
