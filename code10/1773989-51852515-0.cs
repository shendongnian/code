         foreach (Control ctrl in obj_uc_MainMenu.Controls)
            {
                if (ctrl.GetType() == typeof(Button))
                {
                    ((Button)ctrl).Enabled = false;
                }
            }
