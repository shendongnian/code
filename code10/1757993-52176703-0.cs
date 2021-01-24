            string output = "";
			string[] lines = File.ReadAllLines(String.Concat(@textBox1.Text, "\\temp\\test.txt"));
			for (int i = 0; i < lines.Length; i++)
			{
				if (lines[i].Contains("Binh"))
				{
					output = lines[i - 1];
				}
			}
