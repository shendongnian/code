    namespace WindowsFormsApplication2
    {
        using System;
        using System.Windows.Forms;
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                _grid.CellFormatting += new DataGridViewCellFormattingEventHandler( OnGridCellFormatting );
    
                Column1.DisplayMember = "FullDescription";
                Column1.ValueMember = "ID";
                Column1.Items.Add( new AURecord( "1", "First Item" ) );
                Column1.Items.Add( new AURecord( "2", "Second Item" ) );
            }
    
            void OnGridCellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
            {
                if ( ( e.ColumnIndex == Column1.Index ) && ( e.RowIndex >= 0 ) && ( null != e.Value ) )
                {
                    e.Value = _grid.Rows[ e.RowIndex ].Cells[ e.ColumnIndex ].Value;
                }
            }
        }
    
        public class AURecord
        {
            public AURecord( string id, string description )
            {
                this.ID = id;
                this.Description = description;
            }
            public string ID { get; private set; }
            public string Description { get; private set; }
            public string FullDescription
            {
                get { return string.Format( "{0} - {1}", this.ID, this.Description ); }
            }
        }
    }
