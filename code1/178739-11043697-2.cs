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
		public static void Assert<TEventArgs>(EventHandlerCapture<TEventArgs> capture, Action<EventHandlerCapture<TEventArgs>> test, Action code) where TEventArgs : EventArgs {
			capture.Reset();
			code();
			test(capture);
		}
		public static Action<EventHandlerCapture<TEventArgs>> IsNotRaised<TEventArgs>() where TEventArgs : EventArgs {
			return (EventHandlerCapture<TEventArgs> test) => {
				NUnit.Framework.Assert.That(test.WasRaised, Is.False);
			};
		}
		public static Action<EventHandlerCapture<PropertyChangedEventArgs>> IsPropertyChanged(object sender, string name) {
			return (EventHandlerCapture<PropertyChangedEventArgs> test) => {
				NUnit.Framework.Assert.That(test.WasRaised, Is.True);
				NUnit.Framework.Assert.That(test.Sender, Is.SameAs(sender));
				NUnit.Framework.Assert.That(test.EventArgs.PropertyName, Is.EqualTo(name));
			};
		}
	}
