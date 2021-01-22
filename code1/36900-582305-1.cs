    public enum Foo
    {
    	[Description("flibble")]
    	Bar,
    	[Description("wobble")]
    	Baz,
        // none present, will use the name
    	Bat
    	
    }
    Form f = new Form();
    f.Controls.Add(new ListBox() 
    {
        Dock = DockStyle.Fill,
        DataSource = DescriptiveEnum<Foo>.Make(
           new Foo[] { Foo.Bar, Foo.Baz, Foo.Bat }),
    });
    Application.Run(f);
