    private async void notification()
            {
                
                MCDataClassDataContext dataClass = new MCDataClassDataContext(con);
                while (true)
                {
                    await Task.Delay(TimeSpan.FromSeconds(3));
    
                    IQueryable<RendezVous> NotifRdv = (from rendezVous in dataClass.RendezVous
                                                       orderby rendezVous.Date
                                                       select rendezVous);
                    int cpt = 0;
                    if (NotifRdv.Count() != 0)
                    {
    
                        foreach (RendezVous rdv in NotifRdv)
                        {
                            string dateRdv, dateAJRD;
                            dateRdv = rdv.Date.ToString().Substring(0, 10);
                            dateAJRD = DateTime.Today.ToString().Substring(0, 10);
                            if (string.Compare(dateRdv, dateAJRD) == 0)
                            {
                                DateTime t1 = (DateTime)rdv.Date;
                                DateTime t2 = DateTime.Now;
                                TimeSpan t = t2 - t1;
                                if (t.TotalMinutes < Globals.TempRappelRDV)
                                {
                                    if (rdv.IdPatient != 0)
                                    {
                                        if (rdv.Important == true)
                                        {
                                            TextBlock TextRDV = new TextBlock();
                                            IQueryable<Patient> patientRDV = (from patient in dataClass.Patient
                                                                              where rdv.IdPatient == patient.Id
                                                                              select patient);
                                            IQueryable<Personne> personneRDV = (from personne in dataClass.Personne
                                                                                where patientRDV.First().IdPersonne == personne.Id
                                                                                select personne);
                                            string NomPatient = personneRDV.First().nom;
                                            string PrenomPatient = personneRDV.First().prenom;
                                            string heureRDV = rdv.Date.ToString().Substring(10, 9);
                                            TextRDV.Text = " RENDEZ VOUS DANS " + Globals.TempRappelRDV.ToString() + " min \n Patient: \n Nom: " + NomPatient + "\n Prenom: " + PrenomPatient + "\n Heure: " + heureRDV + "\n\t\t" + DateTime.Now.ToString();
                                            ListeNotif.Items.Add(TextRDV);
                                            System.Windows.Forms.NotifyIcon notif = new System.Windows.Forms.NotifyIcon();
                                            notif.Visible = true;
                                            notif.Icon = new System.Drawing.Icon(@"../../ressources/Icones/icones ico/logo_white.ico");
                                            notif.ShowBalloonTip(5000, "Medicare", "Vous un rendez vous important dans " + Globals.TempRappelRDV.ToString() + " minutes ", System.Windows.Forms.ToolTipIcon.Info);
                                            cpt++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                
            }
