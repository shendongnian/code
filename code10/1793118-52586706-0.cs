	public static IEnumerable<ProcessItem> GetItemsFromText(string text) {
		var lines = text.Split( new [] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries );
		ProcessItem current = null;
		Console.WriteLine( "Lines found: {0}", lines.Length );
		// skip first 2 lines (header and = signs)
		for (int i = 2; i < lines.Length; i++) {
			var name = lines[i].Substring( 0, 25 ).Trim();
			var pid = lines[i].Substring( 26, 8 ).Trim();
			var services = lines[i].Substring( 35 ).Trim();
			if (!string.IsNullOrWhiteSpace( name ) ) {
				if (current != null) {
					yield return current;
				}
				current = new ProcessItem {
					Name = name,
					Pid = pid,
					Services = services
				};
			} else {
				current.Services += ' ' + services;
			}
		}
		if (current != null) {
			yield return current;
		}
	}
