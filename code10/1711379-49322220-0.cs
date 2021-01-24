    pb[x, y].MouseHover += new EventHandler(this.PB_MouseHover);
    
    private void PB_MouseHover(object sender, EventArgs e)
    {
        actionmousehoover(x, y)
    }
    
    private void actionmousehoover(int x, int y)
        {
    
            resethoovercolors();
            //Om vertikal
            if(vertorhoriz = false)
            {
                if(y+1 < 10 || y-1 < 1)
                {
                    pb[x, y].BackColor = Color.Red;
                    pb[x, y + 1].BackColor = Color.Red;
                    pb[x, y - 1].BackColor = Color.Red;
    
                }
            }
            if(vertorhoriz = true)
            {
                if(x+1 < 10 || y-1 < 1)
                {
                    pb[x, y].BackColor = Color.Red;
                    pb[x + 1, y].BackColor = Color.Red;
                    pb[x - 1, y].BackColor = Color.Red;
                }
            }
        }
