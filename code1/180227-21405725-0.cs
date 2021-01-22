        public void setAllUpDnBackColorWhite()
        {
            //To set the numericUpDown background color of the selected control to white: 
            //and then the last selected control will change to green.
            foreach (Control cont in this.Controls)
            {
               if (cont.HasChildren)
                {
                    foreach (Control contChild in cont.Controls)
                        if (contChild.GetType() == typeof(NumericUpDown))
                            contChild.BackColor = Color.White;
                }
                if (cont.GetType() == typeof(NumericUpDown))
                    cont.BackColor = Color.White;
           }
        }   
