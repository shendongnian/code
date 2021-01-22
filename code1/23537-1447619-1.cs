public static class Linker {
	public static void Link(Publisher publisher, Control subscriber) {
		// anonymous method references the subscriber only through weak references, so its 
		// existance doesn't interfere with garbage collection
		var subscriber_weak_ref = new WeakReference(subscriber);
		// this instance variable will stay in memory as long as the anonymous method holds a reference to it
		// we declare and initialize it to reserve the memory (also, compiler complains about uninitialized variable otherwise)
		EventHandler&lt;ValueEventArgs&lt;bool>> handler = null;
		// when the handler is created it will grab references to the local variables used within, keeping them in memory after
		// the function scope ends
		handler = delegate(object sender, ValueEventArgs&lt;bool> e) {
			var subscriber_strong_ref = subscriber_weak_ref.Target as Control;
			if (subscriber_strong_ref != null) subscriber_strong_ref.Enabled = e.Value;
			else {
				// unsubscribing the delegate from within itself is risky, but because only one instance exists and nobody else
				// has a reference to it we can do this
				((Publisher)sender).EnabledChanged -= handler;
				// by assigning the original instance variable pointer to null we make sure that nothing else references
				// the anonymous method and it can be collected. After this, the weak reference and the handler pointer itself
				// will be eligible for collection as well.
				handler = null; 
			}
		};
		publisher.EnabledChanged += handler;
	}
}
