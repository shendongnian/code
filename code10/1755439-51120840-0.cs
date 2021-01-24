    public class HospitalAdmission
        {
            //The custom constructor sets all the properties including the calculated valuew.
            public HospitalAdmission(int id, string roomNum, DateTime dateIn, DateTime dateOut, decimal dayRate)
            {
                ID = id;
                RoomNum = roomNum;
                In = dateIn;
                Out = dateOut;
                DayRate = dayRate;
                LengthOfStay = Out.Subtract(In).Days;
                TotalFee = DayRate * LengthOfStay;
            }
            public int ID { get; set; }
            public string RoomNum { get; set; }  
            public DateTime In { get; set; }
            public DateTime Out { get; set; }
            public decimal DayRate { get; set; }
            public int LengthOfStay { get; set; }
            public decimal TotalFee;
        }
        public class DataAccess
        {
            public List<HospitalAdmission> lstHosAdmin = new List<HospitalAdmission>();
            public void GetData()
            {
                //I am not very sure of your select statement. Please check it in SSMS
                //P_id will have to be a column in one of your tables, qualify it with the table name as you have done for the other fields
                string sql = " SELECT dbo.admission.admission_id, dbo.Room.Room_No, dbo.admission.in_date, dbo.admission.out_date, dbo.Room.daily_charges FROM dbo.admission INNER JOIN dbo.Room ON dbo.admission.Room_id = dbo.Room.Room_id WHERE P_id = @pid;";
                //using ensures that you objects are closed and disposed even if there is an error
                using (SqlConnection cnn = new SqlConnection("Your connection string"))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        //Always use parameters to prevent Sql Injection
                        //I assumed P_id was a VarChar because it was surronded by quotes check the db for correct datatype
                        cmd.Parameters.Add("@pid", SqlDbType.VarChar).Value = textBox1.Text;
                        cnn.Open();
                        using (SqlDataReader Reader = cmd.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                //calls the custom constructor passing in the values from the database
                                HospitalAdmission ha = new HospitalAdmission(Reader.GetInt32(0),Reader.GetString(1),Reader.GetDateTime(2), Reader.GetDateTime(3),Reader.GetDecimal(4));
                                lstHosAdmin.Add(ha);
                            }
                        }
                    }
                }
            }
        }
        public partial class Form1 : Form
        {
            private List<HospitalAdmission> lstHA
            private void Form1_Load(object sender, EventArgs e)
            {
                DataAccess da = new DataAccess();
                da.GetData();
                lstHA = da.lstHosAdmin;
                FillListView();
            }
            private void FillListView()
            {
                listView4.GridLines = false;
                listView4.View = View.Details;
                listView4.FullRowSelect = true;
                //Add Column Header
                listView4.Columns.Add("Room ID", 80);
                listView4.Columns.Add("Room No", 80);
                listView4.Columns.Add("Admit Date", 90);
                listView4.Columns.Add("Discharged Date", 90);
                listView4.Columns.Add("Daily Charges", 90);
                listView4.Columns.Add("Stayed Days", 80);
                listView4.Columns.Add("Total Charges", 80);
                listView4.BeginUpdate();
                foreach (HospitalAdmission ha in lstHA)
                { 
                ListViewItem lv1 = new ListViewItem(ha.ID.ToString());
                lv1.SubItems.Add(ha.RoomNum.ToString());
                lv1.SubItems.Add(ha.In.ToString());
                lv1.SubItems.Add(ha.Out.ToString());
                lv1.SubItems.Add(ha.DayRate.ToString());
                lv1.SubItems.Add(ha.LengthOfStay.ToString());
                lv1.SubItems.Add(ha.TotalFee.ToString());
                listView4.items.Add(lv1);
                }
                listView4.EndUpdate();
            }
        }
    }
