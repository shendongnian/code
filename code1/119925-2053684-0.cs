using System;
using System.Collections;
using Gtk;
using MySql.Data.MySqlClient;
using Novell.Directory.Ldap;
public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected virtual void OnEntry1FocusOutEvent (object o, Gtk.FocusOutEventArgs args)
	{
		string conString = "server=localhost;database=ldap;User ID=someid;password=somepassword;";
		string sql = String.Format("Select * From user where barcode='{0}'",txtBarcode.Text);
		string path = "/home/path/to/project/Photo/";
		string expDate = "";
		string usrName = "";
		//creating connection with database
		MySqlConnection dbcon;
		dbcon = new MySqlConnection(conString);
		try
        {
            dbcon.Open();
        }
        catch (Exception ex)
        {
			Console.WriteLine(ex.ToString());
            //Console.WriteLine("MySQL Database Connection Problem !!!");
        }
		//reading data from mysql
		MySqlCommand dbcmd = new MySqlCommand(sql, dbcon);
        MySqlDataReader reader = dbcmd.ExecuteReader();
		
		while(reader.Read()){
			
			txtFirstname.Text = Convert.ToString(reader["first_name"]);
			txtLastname.Text  = Convert.ToString(reader["last_name"]);
			imgUser.File      = path+Convert.ToString(reader["photo"]);
			expDate           = Convert.ToString(reader["expiration_datetime"]);
			usrName           = Convert.ToString(reader["username"]);
			}
		
		dbcon.Close();
				
		//changeing time from sting to datetime
		DateTime dt = Convert.ToDateTime(expDate);
		DateTime now = DateTime.Now;
		txtStatus.Text = dt.ToString();
		//checking if the account has expired
		if(dt > now){
			//connecting with ldap server
			string server = "ip of the server";
			string dn = "cn=Manager,dc=itc";
			string up = "password";
			string dn1 = "uid="+usrName+",ou=people,dc=itc";
			
            // Create a new LdapConnection instance
			LdapConnection connl = new LdapConnection();
            
			// Connect to the server
			connl.Connect(server, 389);
            
			//Bind
			connl.Bind(dn,up);
			
			//Modify user in ldap entry
			ArrayList modList = new ArrayList();
			LdapAttribute attribute;
			//Replace the value of loginshell attribute
			attribute = new LdapAttribute( "loginShell", "/bin/sh");
			modList.Add( new LdapModification(LdapModification.REPLACE, attribute));
			LdapModification[] mods = new LdapModification[modList.Count]; 	
			//Type mtype=Type.GetType("Novell.Directory.LdapModification");
			mods = (LdapModification[])modList.ToArray(typeof(LdapModification));
			
			//Modify the entry in the directory
			connl.Modify ( dn1, mods );
			txtStatus.Text="Account Activated!";
			// Disconnect from server
			connl.Disconnect();
		}else{
			txtStatus.Text="Account Expired!";
			
		}
	}
}
