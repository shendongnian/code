    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.OleDb;
    using System.Data;
    using System.Configuration;
    
    public partial class _default : System.Web.UI.Page
    {
        
    
        protected void Page_Load(object sender, EventArgs e)
        {
    
            //Page Load'da Session kontrolü yapılan alan
    
            
            
            if (Session["Adi"] != null)
            {
                lblAdi.ForeColor = System.Drawing.Color.DarkRed;
                lblAdi.Text = Session["Adi"].ToString();
            }
            else 
            {
                Response.Redirect("KullaniciGirisi.aspx");
            }
            // Alınan işin alınmış olup olmadığını page loadda kontrol edip oturum açıldığında butonları gösterip gizleyen alan
            if (DDLisSec.SelectedIndex == 0)
            {
                btnisBaslat.Enabled = false;
            }
            else
            {
                btnisBaslat.Enabled = true;
            }
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath("Database1.accdb") + "");
            con.Open();
            OleDbCommand cmd = new OleDbCommand("Select tiklama FROM Personel WHERE ID=" + Session["UserID"], con);
            OleDbDataReader dr = cmd.ExecuteReader();
    
            while (dr.Read())
            {
                if (dr["tiklama"].ToString() == "true")
                {
                    btnisBaslat.Visible = false;
                    btnisDurdur.Visible = true;
                    rbtnBekle.Visible = true;
                    rbtnBitir.Visible = true;
                }
                //else if (dr["tiklama"].ToString() == "")
                //{
                //    btnisBaslat.Visible = false;
                //    btnisDurdur.Visible = false;
                //}
                else
                {
                    btnisBaslat.Visible = true;
                    btnisDurdur.Visible = false;
                }
            }
            
    
            con.Close();
            dr.Close();
    
            datalistYapilanisler();
        }
        public void datalistYapilanisler()
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath("Database1.accdb") + "");
            con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT P.ID, P.Adi, P.Soyadi, SUM(DateDiff('n', GH.StartTime,GH.EndTime)) AS ToplamSure FROM (GorevHareket AS GH LEFT JOIN Temsilci AS G ON GH.GorevId = G.ID) LEFT JOIN Personel AS P ON G.personel_id = P.ID WHERE G.Tipdurum = 1 AND GH.Tip = 1 GROUP BY P.ID, P.Adi, P.Soyadi", con);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView5.DataSourceID = null;
            GridView5.DataSource = dt;
            GridView5.DataBind();
            con.Close();
            //GridView5.FooterRow.Cells[1].Text = dt.Compute("Sum(TarihFarki)", "").ToString();
            //TextBox1.Text = GridView5.FooterRow.Cells[1].Text;
    
        }
        protected void btnGrsYap_Click(object sender, EventArgs e)
        {
            Response.Redirect("KullaniciGirisi.aspx");
        }
        protected void btnCikis_Click(object sender, EventArgs e)
        {
            //Sessionları oturumu kapatırken sonlandıran alan
            Session.Abandon();
            Response.Redirect("KullaniciGirisi.aspx");
        }
        protected void btnisBaslat_Click(object sender, EventArgs e)
        {
                    
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath("Database1.accdb") + "");
                con.Open();
                //OleDbCommand cmd = new OleDbCommand("update Personel set is_Tanimi='" + txtisTanimi.Text + "', baslangic_zamani='" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "' where ID = " + Session["UserID"], con);
                OleDbCommand cmd = new OleDbCommand("update Personel set tiklama='true' where ID=" + Session["UserID"], con);
                cmd.ExecuteNonQuery();
                //OleDbCommand cmd2 = new OleDbCommand("INSERT INTO Gorevler(Kadi,is_tanimi,baslangic_zamani,kull_id) values ('" + Session["Adi"] + "','" + DDLisSec.SelectedValue + "','" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "','" + Session["UserID"] + "')", con);
                //cmd2.ExecuteNonQuery();
                OleDbCommand cmd6 = new OleDbCommand("update GorevHareket set EndTime='" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "' WHERE StartTime IS NOT NULL AND EndTime IS NULL AND SessionId=" + Session["UserID"], con);
                cmd6.ExecuteNonQuery();
                        
                OleDbCommand cmd2 = new OleDbCommand("Select * from Temsilci where ID=" + DDLisSec.SelectedValue, con);
                OleDbDataReader dr = cmd2.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["is_durum"].ToString() == "Beklemede")
                    {
                        OleDbCommand cmd4 = new OleDbCommand("UPDATE Temsilci set Tipdurum=1 where Tipdurum=2 AND ID=" + DDLisSec.SelectedValue + " AND personel_id=" + Session["UserID"], con);
                        cmd4.ExecuteNonQuery();
                        OleDbCommand cmd3 = new OleDbCommand("update GorevHareket set EndTime='" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "' WHERE Tip=2 AND EndTime IS NULL AND GorevId=" + DDLisSec.SelectedValue + " AND SessionId=" + Session["UserID"], con);
                        cmd3.ExecuteNonQuery();
                        OleDbCommand cmd7 = new OleDbCommand("INSERT INTO GorevHareket(GorevId,SessionId,Tip,StartTime) SELECT Temsilci.ID,Temsilci.personel_id,'1' AS Tip,'" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "' AS StartTime From Temsilci where Temsilci.Tipdurum=1 and Temsilci.personel_id=" + Session["UserID"], con);
                        cmd7.ExecuteNonQuery();
                                            
                        Response.Write("Beklemede olanlar çalıştı");
                    }
                    else
                    {
                        //Response.Write(DDLisSec.SelectedValue);
                        OleDbCommand cmd4 = new OleDbCommand("UPDATE Temsilci set Tipdurum=1 where ID=" + DDLisSec.SelectedValue + " AND personel_id=" + Session["UserID"], con);
                        cmd4.ExecuteNonQuery();
                        OleDbCommand cmd3 = new OleDbCommand("update GorevHareket set EndTime='" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "' WHERE Tip=2 AND EndTime IS NULL AND GorevId=" + DDLisSec.SelectedValue + " AND SessionId=" + Session["UserID"], con);
                        cmd3.ExecuteNonQuery();
                        //OleDbCommand cmd4 = new OleDbCommand("INSERT INTO Gorevler(is_tanimi,kull_id,durum) values ('" + DDLisSec.SelectedValue + "','" + Session["UserID"] + "',1)", con);
                        //cmd4.ExecuteNonQuery();
                        //OleDbCommand cmd3 = new OleDbCommand("UPDATE Temsilci set temsilcigorevid=Gorevler.ID WHERE Temsilci.ID='" + DDLisSec.SelectedValue + "'", con);
                        //cmd3.ExecuteNonQuery();
                        //OleDbCommand cmd7 = new OleDbCommand("INSERT INTO GorevHareket(GorevId,SessionId,Tip,StartTime) SELECT Gorevler.ID,Gorevler.kull_id,'1' AS Tip,'" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "' AS StartTime From Gorevler where Gorevler.durum=1 and Gorevler.kull_id=" + Session["UserID"], con);
                        //cmd7.ExecuteNonQuery();
                        OleDbCommand cmd7 = new OleDbCommand("INSERT INTO GorevHareket(GorevId,SessionId,Tip,StartTime) SELECT Temsilci.ID,Temsilci.personel_id,'1' AS Tip,'" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "' AS StartTime From Temsilci where Temsilci.Tipdurum=1 and Temsilci.personel_id=" + Session["UserID"], con);
                        cmd7.ExecuteNonQuery();                                        
                        Response.Write("Null lar çalıştı");
                    }
                    
                }
                            
                          
                        
                        //OleDbCommand cmd6 = new OleDbCommand("UPDATE GorevHareket set StartTime='" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "' Where [ID] = (SELECT MAX([ID]) FROM GorevHareket)", con);
                        //cmd6.ExecuteNonQuery();
                          
                
            //cmd.ExecuteNonQuery();
                
                btnisBaslat.Visible = false;
                btnisDurdur.Visible = true;
                rbtnBekle.Visible = true;
                rbtnBitir.Visible = true;
                con.Close();
                dr.Close();
                
    
            
        }
        protected void btnisDurdur_Click(object sender, EventArgs e)
        {
    
    
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath("Database1.accdb") + "");
                con.Open();
                //OleDbCommand cmd = new OleDbCommand("update Personel set tiklama='false' where ID=" + Session["UserID"], con);
                //cmd.ExecuteNonQuery();
                //OleDbCommand cmd2 = new OleDbCommand("update Gorevler set bitis_zamani='" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "' where kull_id=" + Session["UserID"], con);
                //// OleDbCommand cmd2 = new OleDbCommand("UPDATE Gorevler SET bitis_zamani='"+ DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")+ "',kull_id='"+Session["UserID"]+"' FROM Gorevler INNER JOIN Personel ON Personel.ID=Gorevler.kull_id WHERE kull_id="+Session["UserID"],con);
    
                //OleDbCommand cmd2 = new OleDbCommand("UPDATE Gorevler INNER JOIN Personel ON Gorevler.kull_id=Personel.ID SET bitis_zamani='" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "',kull_id='" + Session["UserID"] + "' WHERE kull_id=" + Session["UserID"], con);
                //cmd2.ExecuteNonQuery();
                //OleDbDataReader dr = cmd.ExecuteReader();
                btnisDurdur.Visible = false;
                btnisBaslat.Visible = true;
                if(rbtnBekle.Checked==true)
                {
                    OleDbCommand cmd = new OleDbCommand("update Personel set tiklama='false' where ID=" + Session["UserID"], con);
                    cmd.ExecuteNonQuery();
                    OleDbCommand cmd2 = new OleDbCommand("update Temsilci set Tipdurum=2 WHERE ID=" + DDLisSec.SelectedValue + " and Tipdurum=1 and personel_id=" + Session["UserID"], con);
                    cmd2.ExecuteNonQuery();
                    OleDbCommand cmd4 = new OleDbCommand("update GorevHareket set EndTime='" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "' WHERE Tip=1 AND EndTime IS NULL AND GorevId=" + DDLisSec.SelectedValue + " AND SessionId=" + Session["UserID"], con);
                    cmd4.ExecuteNonQuery();
                    OleDbCommand cmd5 = new OleDbCommand("INSERT INTO GorevHareket(GorevId,Tip,StartTime,SessionId) SELECT Temsilci.ID,'2' AS Tip,'" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "' AS StartTime,Temsilci.personel_id From Temsilci where Tipdurum=2 AND ID=" + DDLisSec.SelectedValue + " AND Temsilci.personel_id=" + Session["UserID"], con);
                    cmd5.ExecuteNonQuery();
                    OleDbCommand cmd3 = new OleDbCommand("update Temsilci set is_durum='Beklemede' where ID="+DDLisSec.SelectedValue+" and personel_id="+Session["UserID"], con);
                    cmd3.ExecuteNonQuery();
                    
                    //OleDbCommand cmd2 = new OleDbCommand("Select top 1 * from Gorevler where kull_id="+Session["UserID"]+" Order by ID DESC",con);
                    //OleDbDataReader dr = cmd2.ExecuteReader();
                    //while (dr.Read())
                    //{
                    //    Response.Write(dr["is_tanimi"].ToString());
                    //}
                }
                else if (rbtnBitir.Checked == true)
                {
                    OleDbCommand cmd = new OleDbCommand("update Personel set tiklama='false' where ID=" + Session["UserID"], con);
                    cmd.ExecuteNonQuery();
                    OleDbCommand cmd2 = new OleDbCommand("UPDATE Gorevler SET bitis_zamani='" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "',is_durum='Bitti' where is_tanimi='" + DDLisSec.SelectedValue + "' and [ID] = (SELECT MAX([ID]) FROM Gorevler)", con);
                    cmd2.ExecuteNonQuery();
                    OleDbCommand cmd3 = new OleDbCommand("update Temsilci set is_durum='Bitti' where isin_adi='" + DDLisSec.SelectedValue + "'and personel_id=" + Session["UserID"], con);
                    cmd3.ExecuteNonQuery();
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand("update Personel set tiklama='false' where ID=" + Session["UserID"], con);
                    cmd.ExecuteNonQuery();
                    OleDbCommand cmd2 = new OleDbCommand("update Gorevler set bitis_zamani='" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "' where kull_id=" + Session["UserID"], con);
                    cmd2.ExecuteNonQuery();
                }
                rbtnBekle.Visible = false;
                rbtnBitir.Visible = false;
                
                con.Close();
            
        }
    
    
        
    
        
    
        protected void DDLisSec_SelectedIndexChanged(object sender, EventArgs e)
        {
    
            
            
        }
    
        protected void rbtnBekle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBekle.Checked==true)
            {
                rbtnBitir.Checked = false;
            }
            else
            {
                rbtnBekle.Checked = false;
            }
        }
        protected void rbtnBitir_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBitir.Checked==true)
            {
                rbtnBekle.Checked = false;
            }
            else
            {
                rbtnBekle.Checked = true;
            }
        }
        protected void btnGWSecimKaldır_Click(object sender, EventArgs e)
        {
            GridView3.SelectedIndex = -1;
        }
    
    
        protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView5.PageIndex = e.NewPageIndex;
            datalistYapilanisler();
        }
    }
