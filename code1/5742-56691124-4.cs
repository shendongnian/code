    class D
    {
        public event EventHandler Event;
        public void RaiseEvent() => Event?.Invoke(this, EventArgs.Empty);
    }
    // ...
	
    var image = new D();
	Console.WriteLine($"Created obj #{image.GetHashCode()}");
	
	image.Event += (sender, e) => Console.WriteLine($"Event from obj #{sender.GetHashCode()}");
	Console.WriteLine($"Subscribed to event of obj #{image.GetHashCode()}");
	
	image.RaiseEvent();
	image.RaiseEvent();
	
	var clone = image.DeepClone();
	Console.WriteLine($"obj #{image.GetHashCode()} cloned to obj #{clone.GetHashCode()}");
	
	clone.RaiseEvent();
	image.RaiseEvent();
