        public List<pricetempstorage> Items { get; private set; }
        private void OK_Click(object sender, EventArgs e)
            {
            	cashier c = new cashier();
            	pricetempstorage pts = new pricetempstorage(); //class
            	int qty = Int32.Parse(QTYNumber.Text);
            	int totalPrice = qty * pts.qtyprice;
            	pts.qtynumber = qty;
            	pts.TotalPrice = totalPrice;
            	Items.Add(pts);
                this.Hide();
            }
