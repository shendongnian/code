     private void CamBox1btn_Click(object sender, EventArgs e)
        {
            Camera Cam = new Camera();          
            if (Cam_bln)
            {
                CamBox1btn.BackgroundImage = Properties.Resources.Camera_button_ON;
                Cam.eventForm += new ShowFrm(backgroundcolor_change_CAM);
                Cam.ShowDialog();
               
            }
            else
            {
                CamBox1btn.BackgroundImage = Properties.Resources.Camera_button_OFF;                
            }
            Cam_bln = !Cam_bln;
        }
        void backgroundcolor_change_CAM()
        {
            Cam_bln = false;
            CamBox1btn.BackgroundImage = Properties.Resources.Camera_button_OFF;
        }
