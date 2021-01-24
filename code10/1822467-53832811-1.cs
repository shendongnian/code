        public SumarneDjelatnosti GetEPonudeDjelatnostiSumarnoList(String appid, String oper, Int16 godina)
        {
            //METODA
            // TODO: unit test GetEPonudeDjelatnostiSumarnoList
            SvcActContext sac = null;
            sac = InitCtx("GetEPonudeDjelatnostiSumarnoList");
            if (appid == null) { appid = ""; }
            oper = OperAlter(appid, sac, oper);
            SumarneDjelatnosti popis = new SumarneDjelatnosti();
            if (!SvcAccessAuth.AccessGranted(appid, sac))
            {
                popis.Odgovor = "Neovlašten pristup.";
                popis.OdgovorStatus = -100;
                LogSvcEvent(appid, sac, "UnauthorizedUse", oper, null, popis.OdgovorStatus.ToString(), popis.Odgovor, 200);
                return popis;
            }
            String dsnc = AppGlobals.DSNd;
            String opmbo = oper.Trim();
            String ust;
            EPonudaOperToken tok = new EPonudaOperToken();
            tok = _GetEPonudaSekOperOvl(appid, sac, oper);
            if (tok.OdgovorStatus < 0)
            {
                popis.Odgovor = tok.Odgovor;
                popis.OdgovorStatus = tok.OdgovorStatus;
                LogSvcEvent(appid, sac, "Error", oper, null, String.Format("GetEPonudaSekOperOvl: {0}, {1}", popis.OdgovorStatus, popis.Odgovor), null, 200);
                return popis;
            }
            ust = tok.DavzuSif;
            LogSvcEvent(appid, sac, "Begin", opmbo, null, dsnc, null, 50);
            using (OdbcConnection ocn = new OdbcConnection(AppGlobals.OdbcCString(true)))
            {
                try
                {
                    ocn.Open();
                }
                catch (Exception ex)
                {
                    popis.Odgovor = "Pristup bazi podataka nije moguć.";
                    popis.OdgovorStatus = -101;
                    LogSvcEvent(appid, sac, "DbAccessError", opmbo, null, popis.OdgovorStatus.ToString(), ex.Message, 200);
                    return popis;
                }
                using (OdbcCommand dbcmd = ocn.CreateCommand())
                {
                    String first = "";
    #if DEBUG
                    first = " first 25 ";
    #endif
                    String sql = @"
                    select " + first + @" p.id, dj.sifra djsifra, dj.naziv djnaziv, 
                    sum((case
                    when r.krevet is null then r.brkrevk 
                    when r.brkrevk is null then r.krevet
                    else r.krevet+r.brkrevk
                    end)) br_kreveta, 
                    sum(r.mjesta) mjesta_bolnice,
                    sum(r.postup) br_postupaka, sum(r.sala) br_sala, 
                    round(sum(
                    (case 
                    when dj.sifra like '%1' then 1
                    else r.sati/40
                    end)
                    ),2)  ordinacija
                    FROM eponudesb p
                    right join radiliste  r on r.eponudesb_id = p.id
                    right join djelzz dj on dj.id = r.djelzz_id
                    where r.godina=2018  
                    and p.davzu_sif='004200420'
                    group by p.id, dj.sifra, dj.naziv
                    order by dj.sifra 
                    into temp djelatnost_izv_temp;
                    ";
					using (OdbcCommand dbcmd1 = ocn.CreateCommand())
					{					
						String sql1 = @"
						select " + first + @"djsifra, djnaziv, round(sum(ordinacija),2) 
						suma_ordinacija from djelatnost_izv_temp
						group by 1,2 into temp djelatnost_izv_sum_temp;
						";
                        using (OdbcCommand dbcmd2 = ocn.CreateCommand())
                        {
                            String sql2 = @"
	                        update djelatnost_izv_temp set 
                            ordinacija=(select suma_ordinacija 
                            from djelatnost_izv_sum_temp 
                            where djelatnost_izv_sum_temp.djsifra=djelatnost_izv_temp.djsifra );
						    ";
                            using (OdbcCommand dbcmd3 = ocn.CreateCommand())
                            {
                                String sql3 = @"
                                select " + first + @"dj.sifra djsifra, dj.naziv djnaziv,
                                trim (g.sifra) ||'-'|| trim(s.sifspr) sprema, 
                                round(sum(t.sati/40),2) sati_spreme
                                FROM eponudesb p
                                left join radiliste  r on r.eponudesb_id = p.id
                                left join djelzz dj on dj.id = r.djelzz_id
                                left join timrad t on t.radiliste_id=r.id
                                left join djelponude dp on dp.id=t.djelponude_id
                                left join strspr s on s.id=dp.strspr_id
                                left join zdrdje z on z.id=dp.zdrdje_id
                                left join tipzdpon ti on ti.id=dp.tipzdpon_id
                                left join grtippon g on ti.grtippon_id=g.id
                                where r.godina=2018 
                                and p.davzu_sif='004200420'
                                group by dj.sifra, dj.naziv, s.sifspr, g.sifra
                                order by dj.sifra, sprema
                                into temp struc_sprem_izv_temp;
						        ";
                                using (OdbcCommand dbcmd4 = ocn.CreateCommand())
                                {
                                    String sql4 = @"
                                    select " + first + @"d.djsifra djsifra, d.djnaziv djnaziv, 
                                    d.br_kreveta br_kreveta,
                                    d.mjesta_bolnice mjesta_bolnice,
                                    d.br_postupaka br_postupaka,
                                    d.br_sala br_sala, d.ordinacija ordinacija,
                                    s.sprema naziv_sprema, s. sati_spreme sati_spreme
                                    from struc_sprem_izv_temp s
                                    left join djelatnost_izv_temp d on d.djsifra=s.djsifra;
						            ";
						            dbcmd.CommandText = sql;
						            dbcmd1.CommandText = sql1;
                                    dbcmd2.CommandText = sql2;
                                    dbcmd3.CommandText = sql3;
                                    dbcmd4.CommandText = sql4;
						            //dbcmd.Parameters.Add("@godina", OdbcType.Int).Value = godina;
						            //dbcmd.Parameters.Add("@davzu_sif", OdbcType.VarChar).Value = ust;
						            try
						            {
							            using (OdbcDataReader dbReader = dbcmd.ExecuteReader())
							            {
								            List<DjelatnostiSumarnoIzv> itl = new List<DjelatnostiSumarnoIzv>();
							            try
							            {
								            using (OdbcDataReader dbReader1 = dbcmd1.ExecuteReader())
								            {
                                                try
							                    {
                                                    using (OdbcDataReader dbReader2 = dbcmd2.ExecuteReader())
                                                    {
                                                        try
							                            {
                                                            using (OdbcDataReader dbReader3 = dbcmd3.ExecuteReader())
                                                            {
                                                                try
							                                    {
                                                                    using (OdbcDataReader dbReader4 = dbcmd4.ExecuteReader())
                                                                    {
									                                    while (dbReader4.Read())
									                                    {
										                                    DjelatnostiSumarnoIzv pspi = new DjelatnostiSumarnoIzv();
                                                                            pspi.SifraDjelatnosti = DBHelper.GetOdbcString(dbReader4, "djsifra", "", true, false);
                                                                            pspi.NazivDjelatnosti = DBHelper.GetOdbcString(dbReader4, "djnaziv", "", true, false);
                                                                            pspi.BrojKreveta = DBHelper.GetOdbcNum(dbReader4, "br_kreveta", (double)0);
                                                                            pspi.BrojMjestaDnevneBolnice = DBHelper.GetOdbcNum(dbReader4, "mjesta_bolnice", (double)0);
                                                                            pspi.BrojPostupakaHemodijalize = DBHelper.GetOdbcNum(dbReader4, "br_postupaka", (double)0);
                                                                            pspi.BrojOperacijskihSala = DBHelper.GetOdbcNum(dbReader4, "br_sala", (double)0);
                                                                            pspi.BrojOrdinacija = DBHelper.GetOdbcNum(dbReader4, "ordinacija", (double)0);
                                                                            pspi.NazivStrucneSpreme = DBHelper.GetOdbcString(dbReader4, "naziv_sprema", "", true, false);
                                                                            pspi.SatiStrucneSpreme = DBHelper.GetOdbcNum(dbReader4, "sati_spreme", (double)0);
										                                    itl.Add(pspi);
									                                        }
									                                            if (itl.Count > 0)
									                                            {
										                                            popis.Lista = itl.ToArray();
										                                            popis.OdgovorStatus = popis.Lista.Length;
									                                            }
									                                            else
									                                            {
										                                            popis.Odgovor = "";
										                                            popis.OdgovorStatus = 0;
										                                            LogSvcEvent(appid, sac, "NoRows", opmbo, null, popis.OdgovorStatus.ToString(), popis.Odgovor, 150);
										                                            return popis;
									                                            }
                                                                        }
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        popis.Odgovor = "Podatke nije moguće učitati.[4.]";
                                                                        popis.OdgovorStatus = -102;
                                                                        LogSvcEvent(appid, sac, "DataReadError", opmbo, null, popis.OdgovorStatus.ToString(), ex.Message, 200);
                                                                        return popis;
                                                                    }
                                                                }
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                popis.Odgovor = "Podatke nije moguće učitati.[3.]";
                                                                popis.OdgovorStatus = -102;
                                                                LogSvcEvent(appid, sac, "DataReadError", opmbo, null, popis.OdgovorStatus.ToString(), ex.Message, 200);
                                                                return popis;
                                                            }
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        popis.Odgovor = "Podatke nije moguće učitati.[Update]";
                                                        popis.OdgovorStatus = -102;
                                                        LogSvcEvent(appid, sac, "DataReadError", opmbo, null, popis.OdgovorStatus.ToString(), ex.Message, 200);
                                                        return popis;
                                                    }
									            }
								            }
								            catch (Exception ex)
								            {
									            popis.Odgovor = "Podatke nije moguće učitati.[2.]";
									            popis.OdgovorStatus = -102;
									            LogSvcEvent(appid, sac, "DataReadError", opmbo, null, popis.OdgovorStatus.ToString(), ex.Message, 200);
									            return popis;
								            }
							            }
						            }
						            catch (Exception ex)
						            {
							            popis.Odgovor = "Podatke nije moguće učitati.";
							            popis.OdgovorStatus = -102;
							            LogSvcEvent(appid, sac, "DataReadError", opmbo, null, popis.OdgovorStatus.ToString(), ex.Message, 200);
							            return popis;
						            }
                                }
                            }
                        }
					}
                }
                LogSvcEvent(appid, sac, "Success", opmbo, null, dsnc, null, 100);
                return popis;
            }
        }
