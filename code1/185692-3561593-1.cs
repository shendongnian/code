    void Add( string m )
    {
        Invoke(new MethodInvoker(
            delegate
            {
                add.Items.Add(m);
            }));
    	//add.Items.Add( m );
    }
