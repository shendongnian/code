    using System.Data.SqlClient;
    using System;
    using System.Data;
    using System.Windows.Forms;
    
    namespace MyPfe
    {
       public class NewUser
       {
           private SqlConnection conn = null;
           
           public NewUser()
           {
               this.conn = new database().connect_utilisateur();
           }
           
           public void AddUser(string nom,string pass, string mail , string profile)
           {
               //Insert into
           }
           
           public bool SearchUser(string login)
           {
               //Select requete
           }
           
           public bool ProfileUser(string log)
           {
               string value = string.Empty;
               var cmd = this.conn.CreateCommand ();
               cmd.CommandText = string.Format("select profile from user where user = '{0}'", log);
               var s = cmd.ExecuteReader ();
               if (s.Read ()) value = s ["profile"].ToString();
               return value == "admin";
           }
       }
    }
