            string sentence = "The quick brown fox jumped over the lazy dog. ";
            string[] split = sentence.Split(new char[] { ' ', '.' });
			string result = "";
			int i = 1;
            foreach (string s in split)
            {
				if (s.Trim() != ""){
					result += (i + " " + s + " ");
					i++;
				}
            }
            Console.WriteLine(result);
