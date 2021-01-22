            if (IsvalidUser(txtUsuario.Text, txtPassword.Text))
            {
                //MessageBox.Show("listo");
                Menu ir = new Menu();
                ir.lblUsuario.Text = txtUsuario.Text;
                this.Hide();
                ir.ShowDialog();   
            }
            else
            {
                MessageBox.Show("Incorrecto, verifique sus datos", "Cecom",MessageBoxButtons.OK,MessageBoxIcon.Error); 
            }
        }
        private bool IsvalidUser(string userName, string password)
        {
            DatosDataContext context = new DatosDataContext();
            var q = from p in context.Usuarios
                    where p.Usuarios1 == txtUsuario.Text
                    && p.Password == txtPassword.Text
                    select p;
            if (q.Any())
            {
                return true;
            }
            else
            {
                return false;               
            }
        }
