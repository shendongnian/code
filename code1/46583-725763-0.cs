        public bool TimerEnable
        {
            set
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.timer.Enabled = value;
                });
            }
        }
        public static void timerEnable()
        {
            var form = Form.ActiveForm as Form1;
            if (form != null)
                form.TimerEnable = true;
        }
