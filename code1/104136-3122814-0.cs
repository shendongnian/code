    try
            {
                servicio.ApplicationKey = "xxxxxxxxxxxxxxxxxxxxxxxxxx";
                servicio.ConnectToFacebook(new List<Enums.ExtendedPermissions>() { Enums.ExtendedPermissions.read_stream, Enums.ExtendedPermissions.publish_stream });
                label2.Text = "Conectado:";
                label1.Text = servicio.Users.GetInfo().first_name + " " + servicio.Users.GetInfo().last_name;
                pictureBox1.Image = servicio.Users.GetInfo().picture_small;
                button2.Text = "Sesión Iniciada";
                button2.Enabled = false;
                checkBox1.Enabled = true;
                numericUpDown1.Enabled = true;
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;
            }catch (FacebookException fe)
            {
                listBox1.Items.Add(fe.Message);
            }
