    using System;
    using GenderType = Hero.GenderType; //This is the shorthand using directive
    public partial class Test : System.Web.UI.Page
    {
    	protected void Page_Load(object sender, EventArgs e)
    	{
    		var myHero = new Hero();
    		myHero.Name = "SpamMan";
    		myHero.PowerLevel = 3;
    		myHero.Gender = GenderType.Male; //instead of myHero.Gender = Hero.GenderType.Male;
    	}
    }
    public class Hero
    {
    	public enum GenderType
    	{
    		Male,
    		Female,
    		Other
    	}
    	public string Name;
    	public int PowerLevel;
    	public GenderType Gender;
    }
