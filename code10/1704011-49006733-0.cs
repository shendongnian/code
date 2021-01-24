    protected void UserType_SelectedIndexChanged(object sender, EventArgs e)
            {
                ImageDef.ImageUrl = "Images/student.png";
                {
                    if (userType.SelectedValue == "Student")
                    {
                        ImageDef.ImageUrl = "Images/student.png";
                    }
                    else if (userType.SelectedValue == "Teacher")
                    {
                        ImageDef.ImageUrl = "Images/teacher.png";
                    }
                    else if (userType.SelectedValue == "Counselor")
                    {
                        ImageDef.ImageUrl = "Images/counselor.png";
                    }
                    else if (userType.SelectedValue == "Parent")
                    {
                        ImageDef.ImageUrl = "Images/parent.png";
                    }
                    else if (userType.SelectedValue == "Principal")
                    {
                        ImageDef.ImageUrl = "Images/principal.png";
                    }
                    else if (userType.SelectedValue == "Admin")
                    {
                        ImageDef.ImageUrl = "Images/admin.png";
                    }
                    else
                    {
                        ImageDef.ImageUrl = "Images/student.png";
                    }
                }
            }
