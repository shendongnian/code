    public void X()
    {
        int vscrollPos = panel1.VerticalScroll.Value;   
        MovieItem NewMovie = new MovieItem();
        NewMovie.SearchMovie(txtSearch.Text);
        NewMovie.Location = new Point(0, ypos - vscrollPos);
        ypos += 196;
    
        panel1.Controls.Add(NewMovie);
    }
