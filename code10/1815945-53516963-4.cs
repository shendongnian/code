    class Game{
        private Player player;
        
        // constructor etc.
        
        public void picturebox1_paint(object sender, PaintEventArgs e){
             Graphics g = e.Graphics;
             player.DrawYourSelf(g);
        }
    }
