    protected override void OnLoad ( EventArgs e )
            {
    
                    if ( _goWrong )
                    {
                            this.MinimumSize = new System.Drawing.Size ( 420, 161 );
                            this.Font = new Font ( "Tahoma", this.Font.Size, this.Font.Style );
                    }
    
                    TextBox box = new TextBox ();                    
                    this.Controls.Add ( box );
                    box.Focus();//<----Add this line here and the textbox will get focus.
            }
