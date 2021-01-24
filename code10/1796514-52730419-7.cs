    public Form1() {
        InitializeComponent();
        obstacles.Add( new Rectangle( pictureBox1.Left, pictureBox1.Top, pictureBox1.Width, pictureBox1.Height ) );
        obstacles.Add( new Rectangle( pictureBox2.Left, pictureBox2.Top, pictureBox2.Width, pictureBox2.Height ) );
        obstacles.Add( new Rectangle( pictureBox3.Left, pictureBox3.Top, pictureBox3.Width, pictureBox3.Height ) );
        obstacles.Add( new Rectangle( -1, 0, 1, this.ClientSize.Height ) ); //left border of form
        obstacles.Add( new Rectangle( this.ClientSize.Width, 0, 1, this.ClientSize.Height ) ); //right border of form
        obstacles.Add( new Rectangle( 0, this.ClientSize.Height, this.ClientSize.Width, 1 ) ); //down border of form
        obstacles.Add( new Rectangle( 0, -1, this.ClientSize.Height, 1 ) ); //up border of form
    }
