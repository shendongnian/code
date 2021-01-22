       dateTimePicker1.MouseWheel +=  new MouseEventHandler(dateTimePicker1_MouseWheel);
           
        private void dateTimePicker1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int incrementValue = SystemInformation.MouseWheelScrollLines;
            //Do increment
        }
