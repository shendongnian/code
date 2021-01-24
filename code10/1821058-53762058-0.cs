     protected void CalRender(object sender, DayRenderEventArgs e)
            {
                con.Open();
                string  cmdRead = "SELECT theday FROM mytable Where theday = '2018-12-11'";
                NpgsqlCommand thedate = new NpgsqlCommand(cmdRead, con);
                var seeme = thedate.ExecuteScalar();
                DateTime dt = Convert.ToDateTime(seeme);
                if (e.Day.Date == dt)
                    {
                        Literal TheLit = new Literal();
                        TheLit.Text = "<br> X";
                        e.Cell.Controls.AddAt(1, TheLit);
                    }
                con.Close();
    
            }
