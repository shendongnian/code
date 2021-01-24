		static void Main(string[] args)
		{
			var messagesList = new List<Message>
			{
				new Message {Text = "mye:service?resp=out&text=some_text&id=854217"},
				new Message {Text = "mye:service?resp=inj&text=some_text&id=854219"},
				new Message {Text = "mye:service?resp=corr&text=some_text&id=854220"},
				new Message {Text = "mye:service?resp=out&text=some_text&id=854223"},
				new Message {Text = "mye:service?resp=inj&text=some_text&id=854227"},
				new Message {Text = "mye:service?resp=corr&text=test&id=854230"}
			};
			Message suitableMessage = messagesList.FirstOrDefault(m => m.Text.Contains("param") || m.Text.Contains("corr"));
			//result:
			//suitableMessage == "mye:service?resp=corr&text=some_text&id=854220"
			//verification
			if (suitableMessage.Text.Contains("param"))
			{
				Console.WriteLine("param");
			}
			if (suitableMessage.Text.Contains("corr"))
			{
				Console.WriteLine("corr");
			}
			//verification 2 - you can replace your LinQ with this code and debug
			Message suitableMessage2;
			string reason;
			string text; // just to make sure that value is not changed by some other thread ...
			foreach (var m in messagesList)
			{
				if (m.Text.Contains("param"))
				{
					suitableMessage2 = m;
					text = m.Text;
					reason = "param";
					break;
				}
				if (m.Text.Contains("corr"))
				{
					suitableMessage2 = m;
					text = m.Text;
					reason = "corr";
					break;
				}
			}
			// verification 3 - replace lambda with method if not sure how to add break point, write logs if cant debug runtime
			Message suitableMessage3 = messagesList.FirstOrDefault(DebugLinq);
			Console.ReadKey();
		}
		private static bool DebugLinq(Message m)
		{
			if (m.Text.Contains("param"))
			{
				// log Text, "param"
				return true;
			}
			if (m.Text.Contains("corr"))
			{
				// log Text, "corr"
				return true;
			}
			return false;
		}
