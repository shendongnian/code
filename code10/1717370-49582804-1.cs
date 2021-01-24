            using (var db = new PolyPrintEntities())
            {
                var sw = new Stopwatch();
                sw.Start();
                IEnumerable<NotificationDto> notifications = db.EmailServiceNotifications
                    .Select(not => new NotificationDto
                    {
                        Notification_ID = not.Notification_ID,
                        StoredProcedure = not.StoredProcedure,
                        SubjectLine = not.SubjectLine,
                        BodyPreface = not.BodyPreface,
                        Frequency = not.Frequency,
                        TakesDateRange = not.TakesDateRange,
                        DateRangeIntervalHours = not.DateRangeIntervalHours,
                        TakesAssociateId = not.TakesAssociateId,
                        NotificationType = not.NotificationType,
                        Associates = not.SubscriptionEvent.SubscriptionSubscribers
                            .Select(ss => new AssociateDto
                            {
                                Record_Number = ss.Associate.Record_Number,
                                Name = ss.Associate.Name,
                                Email = ss.Associate.EMail
                            })
                    });
                sw.Stop();
                Console.WriteLine($"Enumeration:{sw.ElapsedMilliseconds}"); //about .5 seconds
                sw.Reset();
                sw.Start();
                
                //Each item appears to be generated One by One 
                int i = 0;
                foreach (var n in notifications)
                {
                    sw.Stop();
                    Console.WriteLine($"Generation_{i}:{sw.ElapsedMilliseconds}"); //about 1 second
                    var ret = n.GetEmails();
                    db.EmailQueues.AddRange(ret);
                    sw.Start();
                    i++;
                }
                db.SaveChanges();
            }
