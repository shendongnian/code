    public ActionResult Fiche(CompareConfiguration cc, string rsoc)
        {
            if(cc.Adr1 != false || cc.Rsoc != false || cc.CP != false || cc.Ville != false || cc.Tel != false || cc.Mail != false || cc.User_Id != false)
            {
                Session["cc"] = cc;
                Session["rsoc_entreprise"] = rsoc;
            }
            cc = (CompareConfiguration)Session["cc"];
            rsoc = Session["rsoc_entreprise"].ToString();
            bool categorie = cc.profileConf != null ? true : false;
            Models.Entreprise entreprise = new Models.Entreprise();
            DataTable dt_doublons = new DataTable();
            if (rsoc != null)
            {
                dt_doublons = entreprise.search_doublons(cc.Rsoc, cc.Adr1, cc.CP, cc.Ville, cc.Tel, cc.Mail, cc.User_Id, categorie, cc.profileConf.Split(','));
                for (int i = 0; i < dt_doublons.Rows.Count; i++)
                {
                    if(rsoc != dt_doublons.Rows[i]["rsoc"].ToString())
                    {
                        dt_doublons.Rows[i].Delete();
                    }
                }
                dt_doublons.AcceptChanges();
            }
            
            return View(getDoublons(dt_doublons));
        }
