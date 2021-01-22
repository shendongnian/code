		public void Shuffle(Guid guid1, Guid guid2)
		{
			int[] cardsToGet = new int[] { 5, 5, 6, 6, 6, 7, 8, 9 };
			byte[] b1 = guid1.ToByteArray();
			byte[] b2 = guid2.ToByteArray();
			byte[] all = new byte[b1.Length + b2.Length];
			Array.Copy(b1, all, b1.Length);
			Array.Copy(b2, 0, all, b1.Length, b2.Length);
			List<Card> cards = new List<Card>(this);
			Clear();
			for (int c = 0; c < cardsToGet.Length; c++)
			{
				int seed = BitConverter.ToInt32(all, c * 4);
				Random random = new Random(seed);
				for (int d = 0; d < cardsToGet[c]; d++)
				{
					int index = random.Next(cards.Count);
					Add(cards[index]);
					cards.RemoveAt(index);
				}
			}
		}
