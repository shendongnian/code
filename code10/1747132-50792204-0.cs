    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    using System.Configuration;
    using MySql.Data.MySqlClient;
    namespace WebApplication1
    {
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = connect();
            BindData(connection);
            if (IsPostBack)
            {
                data_Update(connection);
            }
        }
        protected MySqlConnection connect()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=marcin;persistsecurityinfo=True;database=test;password=pass");
            con.Open();
            return con;
        }
        protected void BindData(MySqlConnection c)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM pracownicy", c);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);            
            grid.DataSource = ds;
            grid.DataBind();
            usersid.DataSource = ds;
            usersid.DataBind();
            cmd.Dispose();
        }
        protected void ExecuteQuery(string query, MySqlConnection c)    
        {
            MySqlCommand cmd = new MySqlCommand(query, c);
            cmd.BeginExecuteNonQuery();
            cmd.Dispose();
        }
        protected void data_Update(MySqlConnection conn)
        {
            
            string query = "";
            string selected_str = Request.Form["ctl00$MainContent$akcja"];
            string _id = Request.Form["ctl00$MainContent$usersid"];
            string _imie = Request.Form["ctl00$MainContent$imie"];
            string _nazwisko = Request.Form["ctl00$MainContent$nazwisko"];
            string _dzial = Request.Form["ctl00$MainContent$dzial"];
            string _mail = Request.Form["ctl00$MainContent$mail"];
            selected_str = (selected_str != "Wybierz") ? selected_str : "0";
            int selected = Int32.Parse(selected_str);
            
            switch (selected)
            {
                case 1:
                    if ( _imie != "" && _nazwisko != "" && _dzial != "")
                    {
                        query = "INSERT INTO pracownicy(imie,nazwisko,mail,dzial) VALUES ('" + _imie + "', '" + _nazwisko + "', '" + _mail + "', '" + _dzial + "'); ";
                        
                    }
                    else
                    {
                        CreateAlertError("Sprawdź czy zostały podane wymagane dane: imie, nazwisko, dział");
                    }
                    break;
                case 2:
                    if ( _imie != "" && _nazwisko != "" && _dzial != "")
                    {
                        query = "UPDATE pracownicy SET imie='" + _imie + "', nazwisko='" + _nazwisko + "', mail='" + _mail + "', dzial='" + _dzial + "' WHERE id=" + _id + ";";
                        
                    }
                    else
                    {
                        CreateAlertError("Sprawdź czy zostały podane wymagane dane: imie, nazwisko, dział");
                    }
                    break;
                case 3:
                    query = "DELETE FROM pracownicy WHERE id=" + _id +";";
                    break;
                default:
                    break;
            }
            if(query != "")
                ExecuteQuery(query, conn);
        }
        protected void CreateAlertError(string message)
        {
            HyperLink close = new HyperLink();
            Panel alert = new Panel();
            close.CssClass = "close";
            close.Text = "&times;";
            close.Attributes["data-dismiss"] = "alert";
            close.Attributes["aria-label"] = "close";
            close.NavigateUrl = "#";
            alert.CssClass = "alert alert-danger alert-dismissible fade in";
            alert.Controls.Add(close);
            alert.Controls.Add(new LiteralControl(message));
            info_containter.Controls.Clear();
            info_containter.Controls.Add(alert);
        }
    }
}
