    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Collections.ObjectModel;
    
    namespace StackoverflowSpikes
    {
    	public partial class ItemHighlighter : UserControl
    	{
    		ObservableCollection<TextBlock> items = new ObservableCollection<TextBlock>();
    		string[] source = new string[] { "Hello", "World", "System", "SystemDefault", "SystemFolder" };
    		
    		public ItemHighlighter()
    		{
    			InitializeComponent();
    			Loaded += new RoutedEventHandler(ItemHighlighter_Loaded);
    		}
    
    		void ItemHighlighter_Loaded(object sender, RoutedEventArgs e)
    		{
    			foreach (string s in source)
    			{
    				TextBlock item = new TextBlock();
    				item.Inlines.Add(new Run() { Text = "", FontWeight = FontWeights.Bold });
    				item.Inlines.Add(new Run() { Text = s });
    				items.Add(item);
    			}
    			listBox1.ItemsSource = items;
    		}
    
    		private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
    		{
    			string match = textBox1.Text;
    			foreach (TextBlock item in listBox1.Items)
    			{
    				Run bold = ((Run)item.Inlines[0]);
    				Run normal = ((Run)item.Inlines[1]);
    
    				string s = bold.Text + normal.Text;
    
    				if (s.StartsWith(match))
    				{
    
    					bold.Text = s.Substring(0, match.Length);
    					normal.Text = s.Substring(match.Length);
    				}
    				else
    				{
    					bold.Text = "";
    					normal.Text = s;
    				}
    			}
    		}
    	}
    }
