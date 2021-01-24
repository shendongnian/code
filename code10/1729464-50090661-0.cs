       public Form1()
            { 
            }   
                 private void timer4_Tick(object sender, EventArgs e)
                    {
                        if (!workshop.painted)
                        {
                            WorkshopIsPainted = workshop.Painted;
                        }
                        else return;
                    }
