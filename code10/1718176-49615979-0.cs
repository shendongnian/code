            private void PictureBoxForm_Load ( object sender , EventArgs e ) {
    			List<Image> lstImages = new List<Image> ( );
    			//pbxPicture.Image = FunWithPictureBox.Properties.Resources.Picture1;
    			var properties = typeof ( Properties.Resources ).GetProperties ( System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static );
    			foreach ( var propertyinfo in properties ) {
    				if ( propertyinfo.PropertyType.ToString ( ) == "System.Drawing.Bitmap" ) {
    					lstImages.Add ( ( Bitmap ) Properties.Resources.ResourceManager.GetObject ( propertyinfo.Name ) );
    				}
    			}
    		}
