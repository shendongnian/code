    using System;
    using System.Data;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    class Program
    {
    
    	static void Main(string[] args)
    	{
    		var user = new UserInfo();
    
    		var name = GetAttributeFrom<DisplayAttribute>(user, "LoginName").Name;
    
    		var dt = objToDataTable(user);
    
    		Console.ReadLine();
    	}
    
    	public static DataTable objToDataTable(UserInfo obj)
    	{
    		DataTable dt = new DataTable();
    		UserInfo objU = new UserInfo();
    		
    		foreach (PropertyInfo info in typeof(UserInfo).GetProperties())
    		{
    			dt.Columns.Add(GetAttributeFrom<DisplayAttribute>(objU, info.Name).Name);
    		}
    
    		dt.AcceptChanges();
    
    		return dt;
    	}
    
    	public static T GetAttributeFrom<T>(object instance, string propertyName) where T : Attribute
    	{
    		var attrType = typeof(T);
    		var property = instance.GetType().GetProperty(propertyName);
    		return (T)property.GetCustomAttributes(attrType, false).First();
    	}
    
    }
    public class UserInfo
    {
    	[Display(Name = "ID")]
    	public int UserID { get; set; }
    
    	[Display(Name = "FName")]
    	public string FirstName { get; set; }
    
    	[Display(Name = "LName")]
    	public string LastName { get; set; }
    
    	[Display(Name = "Login")]
    	public string LoginName { get; set; }
    
    	[Display(Name = "Company")]
    	public int CompanyID { get; set; }
    }
