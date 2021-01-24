	public OK Ok() => new OK();
	
	public class Event
	{
		public List<Person> people = new List<Person>();
	}
	
	public class Person
	{
		public string email;
	}
	
	public interface IActionResult { }
	
	public class OK : IActionResult { }
	
	public class Invitation
	{
		public Task Add(Person person) => Task.Run(() => { });
	}
	
	public static class _ctx
	{
		public static List<Event> Event = new List<Event>();
		public static Invitation Invitation = new Invitation();
		public static Task SaveChangesAsync() { return Task.Run(() => { }); }
	}
	
	public static class _mailService
	{
		public static Task SendMail(string email, string message) { return Task.Run(() => { }); }
	}
