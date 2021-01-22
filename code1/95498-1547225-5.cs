    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    
    namespace FlagEnumTest {
    	/// <summary>
    	/// Interaction logic for Window1.xaml
    	/// </summary>
    	public partial class Window1 : Window {
    		public Window1() {
    			InitializeComponent();
    		}
    	}
    
    	[Flags]
    	public enum TestErrors {
    		NoError = 0x0,
    		PowerFailure = 0x1,
    		OpenCondition = 0x2,
    	}
    
    	public class TestObject {
    		public TestErrors Errors { get; set; }
    	} 
    
    	/// <summary>
    	/// Provides for two way binding between a TestErrors Flag Enum property and a boolean value.
    	/// TODO: make this more generic and add it to the converter dictionary if possible
    	/// </summary>
    	public class TestErrorConverter : IValueConverter {
    		private TestErrors target;
    
    		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
    			TestErrors mask = (TestErrors)parameter;
    			this.target = (TestErrors)value;
    			return ((mask & this.target) != 0);
    		}
    
    		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
    			this.target ^= (TestErrors)parameter;
    			return this.target;
    		}
    	}
    
    }
