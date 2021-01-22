    bool isDrawing = false;
    public void myCanvas_MouseMove(object sender, EventArgs e)
    {
         if(!isDrawing)
         {
             isDrawing = true;
             // Do drawing here
             isDrawing = false;
         }
    }
