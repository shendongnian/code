     private void panel1_MouseMove(object sender, MouseEventArgs e)
            {
               
               
                
                    if (e.Button == MouseButtons.Left)
                    {
                        ArrayList inList = new ArrayList();
                        inList.Add(e.X);
                        inList.Add(e.Y);
                        list.Add(inList);
                    }
                
           }
 
