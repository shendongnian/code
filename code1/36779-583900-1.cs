                SilverchatDBEntities entity =
                new SilverchatDBEntities(new Uri("http://localhost:65373/WebDataService1.svc", UriKind.Absolute));
            var query = (DataServiceQuery<SCMessages>) from m in entity.SCMessages select m;
            query.BeginExecute(new AsyncCallback(result =>
                                                     {
                                                         try
                                                         {
                                                             var mes = query.EndExecute(result);
                                                             foreach (var r in mes)
                                                             {
                                                                 MessagesLB.Items.Add(string.Format("{0}; {1} - {2}",
                                                                                                    r.MessageDate.
                                                                                                        ToString(
                                                                                                        "d/M hh:mm",
                                                                                                        CultureInfo.
                                                                                                            InvariantCulture),
                                                                                                    r.MessageAuthor,
                                                                                                    r.MessageText));
                                                             }
                                                         }
                                                         catch (Exception ex)
                                                         {
                                                             MessageBox.Show(ex.Message);
                                                         }
                                                     }), null);
