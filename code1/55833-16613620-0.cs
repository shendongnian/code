    protected void Page_Load(object sender, EventArgs e)
        {
            llenaListBox(ListBox1, 0, 10);
        }
        private void llenaListBox(ListBox PoListBox, int PiMinimo, int PiMaximo)
        {
            int Li;
            for (Li = PiMinimo; Li <= PiMaximo; Li++)
            {
                ListItem obj = new ListItem();
                obj.Text  = Li.ToString();
                obj.Value = Li.ToString();
                PoListBox.Items.Add(obj);
            }
        }
