    enum Talen
    {
        Engels=1, Italiaans=2, Portugees=3, Nederlands=4, Duits=5, Dens=6
    }
    
    Talen Geselecteerd;    
    public void Form1()
    {
        InitializeComponent()
        Geselecteerd = Talen.Nederlands;
    }
    
    //You can use the Enum type as parameter, so any enumaration from any enumerator can be used as parameter
    void VeranderenTitel(Enum e)
    {
        this.Text = Convert.ToInt32(e).ToString();
    }
