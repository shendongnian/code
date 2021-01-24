     MainMenu.Player p = null;
     public Overview(MainMenu.Player p)
     {
         InitializeComponent();
         this.p = p;           // initialize here
         name.Text += p.name;
         hp.Text += p.hp.ToString();
         xp.Text += p.xp.ToString() + "/" + p.xpmax.ToString();
         level.Text += p.lvl.ToString();
         curWpn.Text += p.curWeapon;
         curArm.Text += p.curArmor;
         gold.Text += p.gold.ToString();          
    }
