    private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                //IF Image is less than Image list size.
                if (_imageIndex < imageList1.Images.Count)
                {
                    //De-select current item
                    listView1.Items[_imageIndex].Selected = false;
                    //GO to previous entry.
                    _imageIndex--;
                    //Select new item
                    if(_imageIndex>=0){
                       listView1.Items[_imageIndex].Selected = true;
                       listView1.Select();
                    }
                }
            }
            else
            {
                MessageBox.Show("No image.");
            }
        }
