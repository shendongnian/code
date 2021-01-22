    using System.Data.SqlClient;
    using System.Data;
    public partial class _Default : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=RND3 " + "\\" + " SQLEXPRESS;Initial Catalog=SSSolutionFiles;Integrated Security=True");
        public void displaygrid()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from userfile", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "p");
            GridView1.DataSource = ds.Tables["p"];
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label1.Text = txtUserName.Text + "<br>" + txtPassword.Text + "<br>" + txtConfirmPassword.Text + "<br>" + txtConfirmationNumber.Text;
            displaygrid();
            if (!IsPostBack)
                BindDropDownListData();
        }
        public void BindDropDownListData()
        {
            //SqlConnection con = new SqlConnection("Data Source=RND3 " + "\\" + " SQLEXPRESS;Initial Catalog=SSSolutionFiles;Integrated Security=True");
            //SqlConnection mySqlConnection = new SqlConnection();
            {
                try
                {
                    con.Open();
                    SqlCommand mySqlCommand = new SqlCommand("Select username from userfile ", con);
                    SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(mySqlCommand);
                    DataSet myDataSet = new DataSet();
                    mySqlDataAdapter.Fill(myDataSet);
                    //DropDownList1.DataSource = myDataSet;
                    //DropDownList1.DataTextField = "username";
                    //DropDownList1.DataValueField = "username";
                    //DropDownList1.DataBind();
                    CheckBoxList1.DataSource = myDataSet;
                    CheckBoxList1.DataTextField = "username";
                    CheckBoxList1.DataValueField = "username";
                    CheckBoxList1.DataBind();
                }
                catch (Exception ex)
                {
                    Label1.Text = ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into userfile values('" + txtUserName.Text + "','" + txtPassword.Text + "','" + txtConfirmPassword.Text + "','" + txtConfirmationNumber.Text + "')", con);
            con.Open();
            cmd.ExecuteScalar();
            displaygrid();
            BindDropDownListData();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update userfile set confirmnumber='" + txtConfirmationNumber.Text + "', password='" + txtPassword.Text + "',confirmpassword='" + txtConfirmPassword.Text + "' where username='" + txtUserName.Text + "' ", con);
            con.Open();
            cmd.ExecuteScalar();
            displaygrid();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from userfile where username='" + txtUserName.Text + "' ", con);
            con.Open();
            cmd.ExecuteScalar();
            displaygrid();
            BindDropDownListData();
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtConfirmationNumber.Text = "";
            txtUserName.Text = "";
            txtConfirmPassword.Text = "";
            txtPassword.Text = "";
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                foreach (ListItem checkboxitems in CheckBoxList1.Items)
                {
                    checkboxitems.Selected = true;
                }
            }
            else if (CheckBox1.Checked == false)
            {
                foreach (ListItem listItem in CheckBoxList1.Items)
                {
                    listItem.Selected = false;
                }
            }
        }
    }
