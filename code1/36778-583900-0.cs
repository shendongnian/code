    SilverchatDBEntities entity =
                    new SilverchatDBEntities(new Uri("http://localhost:65373/WebDataService1.svc", UriKind.Absolute));
                entity.MergeOption = MergeOption.OverwriteChanges;
                DataServiceQuery<SCMessages> messages = entity.CreateQuery<SCMessages>("SCMessages");
                messages.BeginExecute(
                    result =>
                        {
                            var mess = messages.EndExecute(result);
                            foreach (var mes in mess)
                            {
                                MessagesLB.Items.Add(mes.MessageAuthor);
                            }
                        },
                    null);
