    class Window: WinForms.Form {
        public Window()
        {
            this.Build();
            this.MinimumSize = new Drawing.Size( 320, 200 );
        }
        void Build()
        {
            this.status = new WinForms.TextBox { Dock = WinForms.DockStyle.Bottom };
            this.checkBoxes = new WinForms.CheckedListBox {
                Dock = WinForms.DockStyle.Fill 
            };
            for(int i = 1; i <= 10; ++i) {
                this.checkBoxes.Items.Add(
                    char.ToString( (char) ( 'a' + i ) ),
                    false
                );
            }
            this.checkBoxes.SelectedIndexChanged += (sender, e) => this.UpdateCheckedList();
            this.Controls.Add( this.checkBoxes );
            this.Controls.Add( this.status );
        }
        void UpdateCheckedList()
        {
            string strStatus = "";
            if ( this.checkBoxes.ContainsSet( new int[]{ 2, 4 } ) ) {
                strStatus += "YES";
            }
            this.status.Text = strStatus;
        }
        WinForms.CheckedListBox checkBoxes;
        WinForms.TextBox status;
    }
    static class CheckedListBoxExtension {
        public static bool ContainsSet(this WinForms.CheckedListBox cbl, ICollection<int> values)
        {
            var valueSet = new HashSet<int>( values );
    
            foreach(int index in cbl.CheckedIndices) {
                if ( valueSet.Contains( index ) ) {
                    valueSet.Remove( index );
                        
                }
            }
    
            return valueSet.Count == 0;
         }
    }
