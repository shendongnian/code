        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                LinkButton l = new LinkButton
                {
                    CommandArgument = i.ToString(),
                    Text = i.ToString(),
                };
                l.Click += test_onclick;
                holder.Controls.Add(l);
            }
        }
        protected void test_onclick(object sender, EventArgs e)
        {
            var x = ((LinkButton)sender).CommandArgument;   
        }
