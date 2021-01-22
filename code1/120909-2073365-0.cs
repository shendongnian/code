     public int IdBers
     {
         set { VeiwState["IdBers"] = value; }    
         get { 
                 int idBerVal = 0;
                 if(VeiwState["IdBers"] != null)
                 {
                     int.TryParse(VeiwState["IdBers"].ToString(), out idBerVal);
                 }
                 return idBerVal; 
             }
     }
    protected void Page_Load(object sender, EventArgs e)
    {
        txtTest.Text = IdBers.ToString();
    }
