	    // This defines the command sequence. In this case, "ctrl-m, ctrl-m, 1 or 2 or 3 or 4, A"
		private static List<List<Keys>> command = new List<List<Keys>>{
			new List<Keys>{Keys.Control | Keys.M},
			new List<Keys>{Keys.Control | Keys.M},
			new List<Keys>{Keys.D1, Keys.D2, Keys.D3, Keys.D4 },
			new List<Keys>{Keys.A}
		};
		private static List<Keys> currentKeyStack = new List<Keys>();
		private static DateTime lastUpdate = DateTime.Now;
		// See if key pressed within 750ms (0.75 sec)
		private static TimeSpan lengthOfTimeForChordStroke = new TimeSpan(0, 0, 0, 0, 750);
		protected static void ProcessCmdKey(Keys keyData)
		{
			// Merge Modifiers (Ctrl, Alt, etc.) and key (A, B, 1, 2, etc.)
			Keys keySequence = (Control.ModifierKeys | keyData);
			if ((TimeSpan)(DateTime.Now - lastUpdate) > lengthOfTimeForChordStroke)
			{
				Console.WriteLine("Clear");
				currentKeyStack.Clear();
			}
			int index = currentKeyStack.Count();
			Console.WriteLine("Index: " + index);
			Console.Write("Command: ");
			foreach (List<Keys> key in command)
			{
				foreach (Keys k in key)
				{
					Console.Write(" | " + k.ToString() + " (" + (int)k + ")");
				}
			}
			Console.WriteLine();
			Console.Write("Stack: ");
			foreach (Keys key in currentKeyStack)
			{
				Console.Write(" | " + key.ToString() + " (" + (int)key + ")");
			}
			Console.WriteLine();
			Console.WriteLine("Diff: " + (TimeSpan)(DateTime.Now - lastUpdate) + " length: " + lengthOfTimeForChordStroke);
			Console.WriteLine("#: " + index + "KeySeq: " + keySequence + " Int: " + (int)keySequence + " Key: " + keyData + " KeyInt: " + (int)keyData);
			// .Contains allows variable input, e.g Ctrl-M, Ctrl-M, 1 or 2 or 3 or 4
			if (command[index].Contains(keySequence))
			{
				Console.WriteLine("Added to Stack!");
				currentKeyStack.Add(keySequence);
			}
			else
			{
				// Clear stack since input didn't match
				Console.WriteLine("Clear");
				currentKeyStack.Clear();
			}
			// When command sequence has been met
			if (currentKeyStack.Count == command.Count())
			{
				// Do your thing here...
				Console.WriteLine("CAPTURED: " + currentKeyStack[2]);
			}
			// Reset LastUpdate
			Console.WriteLine("Reset LastUpdate");
			lastUpdate = DateTime.Now;
			Console.WriteLine("\n");
		}
