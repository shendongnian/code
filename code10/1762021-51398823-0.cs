     if (listStatus.Rows.Count != 0)
                        {
                            DateTime tranDate = Convert.ToDateTime(listStatus.Rows[0]["TransactionDate"].ToString());
                            string tranStatus = listStatus.Rows[0]["Status"].ToString();
                            int tranDay = Convert.ToInt32(tranDate.Day.ToString());
                            listStatus.Rows[0].Delete();
                            listStatus.AcceptChanges();
                            if (daynum != "" && dayCounter == tranDay && tranStatus == "GOOD")
                            {
                                day.CellEvent=GoodEvent;
                         
                            }
                           if (daynum != "" && dayCounter == tranDay && tranStatus == "PMCREATED")
                            {
                                day.CellEvent = PMCreatedEvent;
                            }
                            if (daynum != "" && dayCounter == tranDay && tranStatus == "UMREMOTE")
                            {
                                day.CellEvent = UMRemoteEvent;
                            }
                            if (daynum != "" && dayCounter == tranDay && tranStatus == "UMFIELD")
                            {
                                day.CellEvent = UMFieldEvent;
                            }
                            if (daynum != "" && dayCounter == tranDay && tranStatus == "PMPERFORMED")
                            {
                                day.CellEvent = PMPerformedEvent;
                            }
                            if (daynum != "" && dayCounter == tranDay && tranStatus == "NONCOMM")
                            {
                                day.CellEvent = NonCommEvent;
                            }
                        }
                        day.Phrase = new Phrase(daynum, fontday);
                        pTableCal.AddCell(day);
                        day.CellEvent = null;
                        ++count;
                    }
