    private Capture capture = null;
    
    private void btnStart_Click(object sender, System.EventArgs e)
            {
                try
                {
                    if ( capture == null )
                        throw new ApplicationException( "Please select a video and/or audio device." );
                    if ( !capture.Cued )
                        capture.Filename = txtFilename.Text;
                    capture.Start();
                    btnCue.Enabled = false;
                    btnStart.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show( ex.Message + "\n\n" + ex.ToString() );
                }
            }
