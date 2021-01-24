    class MessageFilter : IMessageFilter
	{
		int[] msgToIgnore = new int[] {512, 799, 49632, 49446, 1847, 15, 96, 275, 160, 1848, 674 , 513, 675, 514, 280, 161, 274, 673, 515, 516, 517, 518, 519, 520, 521, 522, 163, 164, 167, 168, 169, 165, 166};
		public bool PreFilterMessage(ref Message m)
		{
			bool match = false;
			foreach (var msg in msgToIgnore)
			{
				if (m.Msg == msg)
					match = true;
			}
			if (!match)
			{
				MessageBox.Show(m.Msg.ToString());
				return true;
			}
			else
				return false;
		}
	}
