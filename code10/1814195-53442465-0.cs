    public void BindMovie(string date)
            {
                try
                {
                    MovieBAL objAccountBAL = new MovieBAL();
                    drpMovie.ValueMember = "Id";
                    drpMovie.DisplayMember = "MovieName";             
                    drpMovie.DataSource = bjAccountBAL.GetMovieByDate(date).ToList();
                }
                catch (Exception ex)
                {
                    ELog.Write(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
