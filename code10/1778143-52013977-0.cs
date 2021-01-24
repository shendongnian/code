	struct Position
	{
		public int Row;
		public int Col;
		public Position(int row, int col)
		{
			this.Row = row;
			this.Col = col;
		}
	}
	
	class Program
	{
		static void Main()
		{
			byte right = 0;
			byte left = 1;
			byte down = 2;
			byte up = 3;
	
			Position[] directions =
			{
				new Position(0, 1), // right
	            new Position(0, -1), // left
	            new Position(1, 0), // down
	            new Position(-1, 0), // up
	        };
	
			int direction = right;
	
			Console.SetBufferSize(100, 100);
			Console.SetWindowSize(Console.BufferWidth, Console.BufferHeight);
	
			List<Position> snake = new List<Position>();
			for (int i = 0; i < 6; i++)
			{
				snake.Add(new Position(0, 1));
			}
	
			Draw(snake, "*");
	
			while (true)
			{
	
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo userImput = Console.ReadKey();
	
					var moves = new []
					{
						new { key = ConsoleKey.LeftArrow, no = right, yes = left },
						new { key = ConsoleKey.RightArrow, no = left, yes = right },
						new { key = ConsoleKey.UpArrow, no = down, yes = up },
						new { key = ConsoleKey.DownArrow, no = up, yes = down },
					}
					
					moves
						.Where(x => x.key == userImput.Key)
						.Where(x => x.no != direction)
						.ToList()
						.ForEach(x => direction = x.yes);
					
					if (userImput.Key == ConsoleKey.S)
					{
						SaveGame(snake);
					}
					
					if (userImput.Key == ConsoleKey.L)
					{
						LoadGame(snake);
					}
				}
	
				Position snakeHead = snake.Last();
				Position snakeNewHead = new Position(snakeHead.Row + directions[direction].Row, snakeHead.Col + directions[direction].Col);
	
				snake.Add(snakeNewHead);
				Draw(snakeNewHead, "*");
	
				Console.SetCursorPosition(snake[0].Col, snake[0].Row);
				Console.Write(' ');
				snake.RemoveAt(0); // take off at the back!!
	
				Thread.Sleep(TimeSpan.FromMilliseconds(100.0));
			}
		}
		
		private static void Draw(List<Position> smth, string str)
		{
			foreach (var position in smth)
			{
				Console.SetCursorPosition(position.Col, position.Row);
				Console.Write(str);
			}
		}
		
		private static void Draw(Position smth, string str)
		{
			Console.SetCursorPosition(smth.Col, smth.Row);
			Console.Write(str);
		}
		
		private static void LoadGame(List<Position> snake)
		{
			snake.Clear();
			snake.AddRange(
				File
					.ReadAllLines("savegame.jcn")
					.Select(x => x.Split(' '))
					.Select(x => new Position(int.Parse(x[0]), int.Parse(x[1]))));
		}
		
		private static void SaveGame(List<Position> snake)
		{
			File.WriteAllLines("savegame.jcn", snake.Select(x => $"{x.Col} {x.Row}"));
		}
	}
	
