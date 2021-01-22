    string getnote = txtdisplay.Text.Trim();
            String filepath = Server.MapPath(@"img\new1.txt");
            System.IO.FileStream ab = new System.IO.FileStream(filepath, System.IO.FileMode.Create);
            System.IO.StreamWriter Write101 = new System.IO.StreamWriter(ab);
            Write101.WriteLine(getnote);
            Write101.Close();
            Response.ClearContent();
