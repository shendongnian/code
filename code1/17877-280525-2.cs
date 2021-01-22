            var flowpanelinOrder = from n in this.Controls.Cast<Control>()
                                   where n is FlowLayoutPanel
                                   orderby int.Parse(n.Tag.ToString())
                                   select n;
            /* non linq
            List<Control> flowpanelinOrder = new List<Control>();
            foreach (Control c in this.Controls)
            {
                if (c is FlowLayoutPanel) flowpanelinOrder.Add(c);                
            }
            flowpanelinOrder.Sort();
             * */
            foreach (FlowLayoutPanel aDaysControl in flowpanelinOrder)
            {
                MessageBox.Show(aDaysControl.Tag.ToString());
            }
