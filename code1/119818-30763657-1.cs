	public class Musician
	{
		public void TuneGuitar()
		{
			Metronome metronome = new Metronome();
			EventHandler<EventArgs> handler = null;
			handler = (sender, args) =>
			{
				// Tune guitar
				// ...
				
				// Unsubscribe from tick event when guitar sound is perfect
				metronome.Tick -= handler;
			};
			
			// Attach event handler
			metronome.Tick += handler;
		}
	}
	
	public class Metronome
	{
		event EventHandler<EventArgs> Tick;
	}
