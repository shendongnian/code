         private void tmrRotate_Tick(object sender, EventArgs e)
        {
            if (IsValidImg(images[counter])) <--- img exist condition
                {
                 image = Image.FromFile(images[counter]);
                 pxbxImages.Dispose();
                 pxbxImages.Image = image;
                }
        }
