    class CheckBoxesWindow: Form {
        public Window()
        {
            this.Build();
            
            var row1 = new ListViewItem( "Do the dishes", 0 );
            row1.SubItems.Add( "High" );
            row1.Checked = true;
    
            var row2 = new ListViewItem( "Wash sheets", 1 );
            row2.SubItems.Add( "Average" );
        
            this.lvView.Items.AddRange( new ListViewItem[]{ row1, row2 } );
        }
        
        void Build()
        {
            var lv = this.BuildListView();
            
            this.Controls.Add( lv );
            this.Show();
        }
    
        ListView BuildListView()
        {
            int width = this.ClientSize.Width;
            var toret = new ListView{ Dock = DockStyle.Fill };
            
            toret.View = View.Details;
            toret.CheckBoxes = true;
            toret.Columns.Add( "Desc", (int) ( width * 0.70 ), HorizontalAlignment.Center );
            toret.Columns.Add( "Priority", (int) ( width * 0.30 ), HorizontalAlignment.Right );
            
            this.lvView = toret;
            return toret;
        }
        
        ListView lvView;
    }
