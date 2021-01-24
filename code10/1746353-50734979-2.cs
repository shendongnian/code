        MySqlDataReader MyReader2;
        MyConn2.Open();
        MyReader2 = MyCommand2.ExecuteReader();
        while (MyReader2.Read())
        {
            txtno = Convert.ToInt32(MyReader2["task_comment"].ToString());
            TextBox bx = new TextBox();
            bx.Text = txtno;
            // retrieve here any other data u need to assign to the textbox
            bx.Location = new Point(x, y);// x and y should be the calculated //coordinates, this will depend on how you want to display the textboxes
            this.Controls.Add(bx);// Add the textbox to the form
        }
        MyConn2.Close(); //Connection closed here 
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
