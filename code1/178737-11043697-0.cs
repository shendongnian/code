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
			Event.TestEvent(e, () => t.Name = null, Event.WasNotRaised<PropertyChangedEventArgs>());
			t.Name = "test";
			Event.TestEvent(e, () => t.Name = "test", Event.WasNotRaised<PropertyChangedEventArgs>());
		}
		[Test]
		public void Test_DifferentValue() {
			var t = new ClassUnderTest();
			var e = new EventHandlerCapture<PropertyChangedEventArgs>();
			t.NameChanged += e.Handler;
			Event.TestEvent(e, () => t.Name = "test", Event.WasPropertyChanged(t, "Name"));
			Event.TestEvent(e, () => t.Name = null, Event.WasPropertyChanged(t, "Name"));
		}
	}
	/// <summary>Class to capture events</summary>
	public class EventHandlerCapture<TEventArgs> where TEventArgs : EventArgs {
		public EventHandlerCapture() {
			this.Reset();
		}
		public object Sender { get; private set; }
		public TEventArgs EventArgs { get; private set; }
		public bool WasRaised { get; private set; }
		public void Reset() {
			this.Sender = null;
			this.EventArgs = null;
			this.WasRaised = false;
		}
		public void Handler(object sender, TEventArgs e) {
			this.WasRaised = true;
			this.Sender = sender;
			this.EventArgs = e;
		}
	}
	/// <summary>Contains things that make tests simple</summary>
	public static class Event {
		public static void TestEvent<TEventArgs>(EventHandlerCapture<TEventArgs> capture, Action code, Action<EventHandlerCapture<TEventArgs>> test) where TEventArgs : EventArgs {
			capture.Reset();
			code();
			test(capture);
		}
		public static Action<EventHandlerCapture<TEventArgs>> WasNotRaised<TEventArgs>() where TEventArgs : EventArgs {
			return (EventHandlerCapture<TEventArgs> test) => {
				Assert.That(test.WasRaised, Is.False);
			};
		}
		public static Action<EventHandlerCapture<PropertyChangedEventArgs>> WasPropertyChanged(object sender, string name) {
			return (EventHandlerCapture<PropertyChangedEventArgs> test) => {
				Assert.That(test.WasRaised, Is.True);
				Assert.That(test.Sender, Is.SameAs(sender));
				Assert.That(test.EventArgs.PropertyName, Is.EqualTo(name));
			};
		}
	}
