    public class Employ : IOracleCustomType, INullable
    {
        [OracleObjectMapping("FNAME")]
        public string Fname{ get; set; }
        [OracleObjectMapping("LNAME")]
        public string Lname{ get; set; }
        public void FromCustomObject(OracleConnection con, IntPtr pUdt)
        {
            OracleUdt.SetValue(con, pUdt, "FNAME", this.Fname);
            OracleUdt.SetValue(con, pUdt, "LNAME", this.Lname);
        }
        public void ToCustomObject(OracleConnection con, IntPtr pUdt)
        {
            this.Fname = OracleUdt.GetValue(con, pUdt, "FNAME").ToString();
            this.Lname = OracleUdt.GetValue(con, pUdt, "LNAME").ToString();
        }
    }
