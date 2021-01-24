        private bool handling=false;
        private void button42_Click(object sender, EventArgs e)
        {
            if(!handling)
            {
                handling=true;
                SendKeys.Send("A");
                Task.Delay(100);
                handling=false;
           }
        }
