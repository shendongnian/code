	public class ApplicationUser : IdentityUser
	{
		// Later: public List<ShoppingCart> ShoppingCarts { get; set; }
		public ShoppingCart ShoppingCart { get; set; }
	}
	public class ShoppingCart
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
	}
