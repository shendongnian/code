	void Main()
	{
		GetAnimalsFromServer<Pelican>();
		GetAnimalsFromServer<Penguin>();
	}
	
	public class Animal { }
	
	public class Bird : Animal { }
	
	public class Pelican : Bird { }
	
	public class Penguin : Bird { }
	
	public static class _serverConnection
	{
		public static Task<Pelican[]> GetPelicansFromServer()
		{
			Console.WriteLine("Got Pelicans");
			return Task.Run(() => new Pelican[] { });
		}
		public static Task<Penguin[]> GetPenguinsFromServer()
		{
			Console.WriteLine("Got Penguins");
			return Task.Run(() => new Penguin[] { });
		}
	}
