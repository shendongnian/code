	public class ClassUnderTest {
		private string name;
		public string Name {
			get { return this.name; }
			set {
				if (value != this.name) {
					this.name = value;
					NameChanged(this, new PropertyChangedEventArgs("Name"));
				}
			}
		}
		public event EventHandler<PropertyChangedEventArgs> NameChanged = delegate { };
	}
	[TestFixture]
	public class MyTests {
		[Test]
		public void Test_SameValue() {
			var t = new ClassUnderTest();
			var e = new EventHandlerCapture<PropertyChangedEventArgs>();
			t.NameChanged += e.Handler;
			Event.Assert(e, Event.IsNotRaised<PropertyChangedEventArgs>(), () => t.Name = null);
			t.Name = "test";
			Event.Assert(e, Event.IsNotRaised<PropertyChangedEventArgs>(), () => t.Name = "test");
		}
		[Test]
		public void Test_DifferentValue() {
			var t = new ClassUnderTest();
			var e = new EventHandlerCapture<PropertyChangedEventArgs>();
			t.NameChanged += e.Handler;
			Event.Assert(e, Event.IsPropertyChanged(t, "Name"), () => t.Name = "test");
			Event.Assert(e, Event.IsPropertyChanged(t, "Name"), () => t.Name = null);
		}
	}
