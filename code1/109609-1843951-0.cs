    static void Main(string[] args)
    {
            
        using (Game1 game = new Game1())
        {
                ((System.Windows.Forms.Form)System.Windows.Forms.Form.FromHandle(game.Window.Handle)).Icon = new System.Drawing.Icon("file.ico");
                game.Run();
        }
    }
