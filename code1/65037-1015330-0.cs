public partial class TestWindow : Window {
		ObservableCollection&lt;TestClass&gt; oc;
		public TestWindow() {
			InitializeComponent();
			oc = new ObservableCollection&lt;TestClass&gt;();
			foreach( char c in "abcdefghieeddjko" ) {
				oc.Add( new TestClass( c.ToString(), c.ToString(), c.GetHashCode() ) );
			}
			
			lstbox.ItemsSource = oc;
			lstbox.Items.SortDescriptions.Add( new SortDescription("A", ListSortDirection.Ascending) );
			oc.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler( oc_Sort );
		}
		void oc_Sort( object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e ) {
			var items = oc.OrderBy&lt;TestClass, int&gt;( ( x ) =&gt; ( x.C ) );
			ObservableCollection&lt;TestClass&gt; temp = new ObservableCollection&lt;TestClass&gt;();
			foreach( var item in items ) {
				temp.Add( item );
			}
			oc = temp;
		}
		private void Button_Click( object sender, RoutedEventArgs e ) {
			string a = "grrrr";
			string b = "ddddd";
			int c = 383857;
			oc.Add( new TestClass( a, b, c ) );
		}
	}
	public class TestClass : INotifyPropertyChanged {
		private string a;
		private string b;
		private int c;
		public TestClass( string f, string g, int i ) {
			a = f;
			b = g;
			c = i;
		}
		public string A {
			get { return a; }
			set { a = value; OnPropertyChanged( "A" ); }
		}
		public string B {
			get { return b; }
			set { b = value; OnPropertyChanged( "B" ); }
		}
		public int C {
			get { return c; }
			set { c = value; OnPropertyChanged( "C" ); }
		}
		#region onpropertychanged
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged( string propertyName ) {
			if( this.PropertyChanged != null ) {
				PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
			}
		}
		#endregion
	}
