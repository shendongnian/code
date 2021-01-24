        public void YENI_ALM_SIFARISI_AC(
            decimal TEKLIF_BEDELI2,
            string REFERANS_NO,
            string CARIKOD,
            string CARIAD,
            string ACIKLAMA,
            int SUB_ID,
            int DETAY_ID,
            string DETAY,
            decimal SUB_TEKLIF,
            decimal QIYMET,
            string OLCU_VAHIDI,
            decimal IS_HECMI
            )
        {
            var parameters = new foo();
            using (SqlConnection con = new SqlConnection(CS))
            {               
                SqlCommand cmd = new SqlCommand("YENI_ALM_SIFARISI_AC", con);
                foreach (var prop in  parameters.GetType().GetProperties())
                {
                    cmd.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(parameters, null));
                }
                con.Open();
                int DataID = (int)cmd.ExecuteScalar();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(DataID));
                //cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public class foo
        {
            decimal TEKLIF_BEDELI2   { get; set; }
            string REFERANS_NO       { get; set; }
            string CARIKOD           { get; set; }
            string CARIAD            { get; set; }
            string ACIKLAMA          { get; set; }
            int SUB_ID               { get; set; }
            int DETAY_ID             { get; set; }
            string DETAY             { get; set; }
            decimal SUB_TEKLIF       { get; set; }
            decimal QIYMET           { get; set; }
            string OLCU_VAHIDI       { get; set; }
            decimal IS_HECMI         { get; set; }
        }
