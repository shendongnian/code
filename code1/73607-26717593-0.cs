    public static void SetToolTip( Control control, string text )
        {
            if ( String.IsNullOrEmpty( text ) )
            {
                if ( tooltips.ContainsKey(control.Name ) )
                {
                    GetControlToolTip( control ).RemoveAll();
                    tooltips.Remove( control.Name );
                }
            }
            else
            {
                ToolTip tt = GetControlToolTip( control );
                tt.SetToolTip( control, text );
            }
        }
