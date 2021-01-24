public class User
{
	public int UserId { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string CreditCardNumberLastFour { get; set; }
	public string EmailAddress { get; set; }
	public long PhoneNumber { get; set; }
	public bool UserInSession { get; set; }
	public Card Card { get; set; }
}
interface IValidator<T> {
    bool Validate(T t);
}
class UserValidator : IValidator<User> {
    public bool Validate(User u) {
        // check for numbers only
        if (!Regex.IsMatch(value.CreditCardNumberLastFour, @"^\d+$")
        {
    		return false;
    	}
        // ensure length is 4
    	if (value.CreditCardNumberLastFour.Length != 4)
    	{
    		return false;
    	}
        // add more checks here if needed ....
    }
}
Then you can do in your code
//POST api/values
public void Post([FromBody]User value)
{
	var validator = new UserValidator();
	if (!validator.Validate(value)){
	{
		return;
	}
	using (var db = new MembershipContext())
	{
		value = new User();
		db.Users.Add(value);
		db.SaveChanges();
	}
}
