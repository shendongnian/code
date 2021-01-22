    public void X()
    {
        panel1.SuspendLayout();
    
        MovieItem NewMovie = new MovieItem();
        NewMovie.SearchMovie(txtSearch.Text);
        NewMovie.Location = new Point(0, ypos);
        ypos += 196;
    
        panel1.Controls.Add(NewMovie);
    
        panel1.ResumeLayout();
    }
