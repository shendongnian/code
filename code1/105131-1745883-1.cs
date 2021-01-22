    foreach (GridViewRow myRow in GridView1.Rows)
            {
                Image img1 = (Image)myRow.FindControl("Image1");
                CheckBox chkbox1 = (CheckBox)myRow.FindControl("CheckBox1");
                if (chkbox1.Checked)
                {
                    img1.ImageUrl = "~/greenimage.jpg";
                }
                else
                {
                    img1.ImageUrl = "~/redimage.jpg";
                }
            }
