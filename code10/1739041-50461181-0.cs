        private void btnNext_Click(object sender, EventArgs e)
        {
            //IF Image is less than Image list size.
            if (_imageIndex < imageList1.Images.Count)
            {
                listView1.Items[_imageIndex].Selected = true;
                _imageIndex++;
            }
        }
