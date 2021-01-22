    public partial class Form1 : Form
    {
    bool clicked = false;
    CheckBoxState state;
    public Form1()
    {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.Columns.Add("Col1", 150);
            listView1.Columns.Add("Col2", 150);
            listView1.Columns.Add("Col3", 150);
            listView1.Columns.Add("Col4", 150);
            listView1.HeaderStyle = ColumnHeaderStyle.Clickable;
            listView1.CheckBoxes = true;
            listView1.OwnerDraw = true;
 
            for(int i = 0; i < 10; i++)
                listView1.Items.Add("Value " + i);
        }
 
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (!clicked)
            {
                clicked = true;
                state    = CheckBoxState.CheckedPressed;
 
                foreach (ListViewItem item in listView1.Items)
                {
                    item.Checked = true;
                }
 
                Invalidate();
            }
            else
            {
                clicked = false;
                state = CheckBoxState.UncheckedNormal;
                Invalidate();
 
                foreach (ListViewItem item in listView1.Items)
                {
                    item.Checked = false;
                }
            }           
        }
 
        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.LeftAndRightPadding;
            e.DrawBackground();
            CheckBoxRenderer.DrawCheckBox(e.Graphics, ClientRectangle.Location, state);
            e.DrawText(flags);
        }
 
        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
 
        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }
    }
    }
