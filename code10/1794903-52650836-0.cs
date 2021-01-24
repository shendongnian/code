        private void dvmVoltageSet(object sender, VoltageEventArgs e)
        {
            VoltageSet = e.VolSet;
            TestLvdtNull(tbMessage);
            TestLvdtNull(tbMessage2);
        }
        
        private void TestLvdtNull(Control control)
        {
            control.BeginInvoke((MethodInvoker)delegate()
                {
                    control.Location += new Point((int)(x / 2 - 250), 150);
                });
        }
