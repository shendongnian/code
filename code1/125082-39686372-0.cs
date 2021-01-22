    private void pictureBox6_Click(object sender, EventArgs e)
            {
                if (bmp2 != null)
                {
                    bmp2.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    pictureBox6.Image = bmp2;
                }
            }
