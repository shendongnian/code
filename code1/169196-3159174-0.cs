        /// <summary>
        /// Finds all controls with the given type anywhere under the root
        /// </summary>
        public static IList<Control> FindControlsRecursive<FindType>( this ControlCollection root )
        {
            Type toFind = typeof( FindType );
            List<Control> controls = new List<Control>();
            if ( root != null && root.Count > 0 )
            {
                foreach ( Control control in root )
                {
                    if ( control != null && ( toFind.IsAssignableFrom( control.GetType() ) ) )
                    {
                        controls.Add( control );
                    }
                    if ( control != null )
                    {
                        controls.AddRange( control.Controls.FindControlsRecursive<FindType>() );
                    }
                }
            }
            return controls;
        }
