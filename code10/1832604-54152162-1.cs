    using System.ComponentModel;
    using System.Windows;
    
    namespace StackHelp
    {
    	/// <summary>
    	/// Interaction logic for MyCalculator.xaml
    	/// </summary>
    	public partial class MyCalculator : Window, INotifyPropertyChanged
    	{
    		public event PropertyChangedEventHandler PropertyChanged;
    
    		public MyCalculator()
    		{
    			DataContext = this;
    			InitializeComponent();
    		}
    
    		private void OnPropertyChanged(string propertyName)
    		{
    			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    		}
    
    		private string m_equationText;
    
    		private string _displayText = "Hi";
    		public string DisplayText
    		{ get { return _displayText; }
    			set { _displayText = value;
    					OnPropertyChanged( "DisplayText" );
    			}
    		}
    
    
    		private void AnyButton_Click(object sender, RoutedEventArgs e)
    		{
    			var whichBtn = sender as System.Windows.Controls.Button;
    			if (whichBtn == null)
    				return;
    
    			// pre-clear just because it was sample anyhow.
    			if (_displayText == "Hi")
    				_displayText = "";
    
    			switch( whichBtn.Content )
    			{
    				case "0":
    				case "1":
    				case "2":
    				case "3":
    				case "4":
    				case "5":
    				case "6":
    				case "7":
    				case "8":
    				case "9":
    					DisplayText += whichBtn.Content;
    					break;
    
    				case "+":
    				case "-":
    				case "*":
    				case "/":
    				case "=":
    					// how to handle...  using your computation learning method
    					// then finish by setting the display text with the new string 
    					// represented answer
    					break;
    
    				default:
    					// invalid button
    					break;
    			}
    
    		}
    	}
    }
