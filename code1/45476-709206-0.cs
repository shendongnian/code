    void button1_Click( object sender, EventArgs e ) {
        var thread = new Thread( ParalelMethod );
        thread.Start( "hello world" );
    }
    void ParalelMethod( object arg ) {
       if ( this.InvokeRequired ) {
           Action<object> dlg = ParalelMethod;
           this.Invoke( dlg, arg );
       }
       else {
           this.button1.Text = arg.ToString();
       }
    }
