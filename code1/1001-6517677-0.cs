        string url;
        regno = GridView1.Rows[e.NewEditIndex].Cells[1].Text;
        exm = GridView1.Rows[e.NewEditIndex].Cells[2].Text;
        brd = GridView1.Rows[e.NewEditIndex].Cells[3].Text;
        cleg = GridView1.Rows[e.NewEditIndex].Cells[4].Text;
        strm = GridView1.Rows[e.NewEditIndex].Cells[5].Text;
        mrks = GridView1.Rows[e.NewEditIndex].Cells[6].Text;
        inyear = GridView1.Rows[e.NewEditIndex].Cells[7].Text;
        url = "academicinfo.aspx?regno=" + regno + ", " + exm + ", " + brd + ", " + cleg + ", " + strm + ", " + mrks + ", " + inyear;
        Response.Redirect(url); 
       
    }
