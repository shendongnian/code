     var myEvent = new Microsoft.Graph.Event();
                    myEvent.Subject = "Test";
                    myEvent.Body = new ItemBody() { ContentType = BodyType.Text, Content = "This is test." };
                    myEvent.Start = new DateTimeTimeZone() { DateTime = "2018-9-29T12:00:00", TimeZone = "Pacific Standard Time" };
                    myEvent.End = new DateTimeTimeZone() { DateTime = "2018-9-29T13:00:00", TimeZone = "Pacific Standard Time" };
                    myEvent.Location = new Location() { DisplayName = "In.gredients" }; 
                     
    
                    // Create the event. 
                    var mySyncdEvent = await graphClient.Users["you maile"].Calendar.Events.Request()
                                                                           .AddAsync(myEvent);
