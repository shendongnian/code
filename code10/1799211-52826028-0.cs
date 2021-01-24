        private void HookEvents( Control Parent )
        {
            foreach ( Control Child in Parent.Controls )
            {
                if ( Child is PictureBox )
                {
                    Child.MouseDown += new EventHandler( OnPictureBoxMouseDown );
                    if ( Child.Controls.Count > 0 )
                    {
                        HookEvents( Child );
                    }
                }
            }
        }
