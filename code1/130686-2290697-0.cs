    public partial class Form1 : Form
    {
    	private class ComboBoxItem
    	{
    		public int Value { get; set; }
    		public string Text { get; set; }
    		public bool Selectable { get; set; }
    	}
    
    	public Form1() {
    		InitializeComponent();
    	}
    
    	private void Form1_Load(object sender, EventArgs e) {
    		this.comboBox1.ValueMember = "Value";
    		this.comboBox1.DisplayMember = "Text";
    		this.comboBox1.Items.AddRange(new[] {
    			new ComboBoxItem() { Selectable = false, Text="Unselectable", Value=0},
    			new ComboBoxItem() { Selectable = true, Text="Selectable1", Value=1},
    			new ComboBoxItem() { Selectable = true, Text="Selectable2", Value=2},
    			new ComboBoxItem() { Selectable = false, Text="Unselectable", Value=3},
    			new ComboBoxItem() { Selectable = true, Text="Selectable3", Value=4},
    			new ComboBoxItem() { Selectable = true, Text="Selectable4", Value=5},
    		});
    
    		this.comboBox1.SelectedIndexChanged += (cbSender, cbe) => {
    			var cb = cbSender as ComboBox;
    
    			if (cb.SelectedItem != null && cb.SelectedItem is ComboBoxItem && ((ComboBoxItem) cb.SelectedItem).Selectable == false) {
    				// deselect item
    				cb.SelectedIndex = -1;
    			}
    		};
    	}
    }
