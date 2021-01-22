     protected void Search_Click(object sender, EventArgs e)
            {
                if (RadioGoogle.Checked)
                    Response.Write("Search Google for " + SearchFor.Text);
                if (RadioCustom.Checked)
                    Response.Write("Search Custom for " + SearchFor.Text);
            }
