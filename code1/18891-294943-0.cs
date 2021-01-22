        // execute this method once all forms have been created
        public static void HookButtons()
        {
             foreach( Form f in Application.OpenForms )
	         {
		          EnumerateControls( f.Controls );
	         }
        }
		public static void EnumerateControls( ICollection controls )
		{
			foreach( Control ctrl in controls )
			{
				if( ctrl.Controls.Count > 0 )
				{
					EnumerateControls( ctrl.Controls );
				}
				if( ctrl is ButtonBase )
				{
					ctrl.MouseClick +=new MouseEventHandler( ctrl_MouseClick );
				}
			}
		}
		static void ctrl_MouseClick( object sender, MouseEventArgs e )
		{
			ButtonBase clicked = ((ButtonBase)sender);
			// do something with the click information here
		}
