    public partial class Form1 : Form
        { 
            public Form1()
            {
                InitializeComponent(); 
            }
    
            /// <summary>
            /// Register event button.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void button1_Click(object sender, EventArgs e)
            {
                graphTesting();
            } 
    
            // Testing out MSGraph
            public async void graphTesting()
            { 
                // Initialize the GraphServiceClient.
                // GraphServiceClient graphClient = Microsoft_Graph_SDK_ASPNET_Connect.Helpers.SDKHelper.GetAuthenticatedClient();
                var graphClient = AuthenticationHelper.GetAuthenticatedClient();
    
                var myEvent = new Microsoft.Graph.Event();
                myEvent.Subject = "Test";
                myEvent.Body = new ItemBody() { ContentType = BodyType.Text, Content = "This is test." };
                myEvent.Start = new DateTimeTimeZone() { DateTime = "2018-10-3T12:00:00", TimeZone = "Pacific Standard Time" };
                myEvent.End = new DateTimeTimeZone() { DateTime = "2018-10-3T13:00:00", TimeZone = "Pacific Standard Time" };
                myEvent.Location = new Location() { DisplayName = "conf room 1" };
    
                var myEvent2 = new Microsoft.Graph.Event();
                myEvent2.Subject = "Test";
                myEvent2.Body = new ItemBody() { ContentType = BodyType.Text, Content = "This is test." };
                myEvent2.Start = new DateTimeTimeZone() { DateTime = "2018-10-4T12:00:00", TimeZone = "Pacific Standard Time" };
                myEvent2.End = new DateTimeTimeZone() { DateTime = "2018-10-4T13:00:00", TimeZone = "Pacific Standard Time" };
                myEvent2.Location = new Location() { DisplayName = "conf room 1" };
    
    
                // Create the event.
                //var user = graphClient.Users["test@test.onmicrosoft.com"].Calendar.Events.Request();
                await graphClient.Users["test@test.onmicrosoft.com"].Calendar.Events.Request().AddAsync(myEvent);
                await graphClient.Users["test@test.onmicrosoft.com"].Calendar.Events.Request().AddAsync(myEvent2);
                await graphClient.Users["test@test.onmicrosoft.com"].Calendar.Events.Request().AddAsync(myEvent);
                await graphClient.Users["test@test.onmicrosoft.com"].Calendar.Events.Request().AddAsync(myEvent2);
                
            }
    
    
    
            /// <summary>
            /// Sign in button.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private async void button2_Click(object sender, EventArgs e)
            { 
                if (await SignInCurrentUserAsync())
                {
    
                }           
            }
    
            public async Task<bool> SignInCurrentUserAsync()
            {
                try
                {
                    var graphClient = AuthenticationHelper.GetAuthenticatedClient();
    
                    if (graphClient != null)
                    {
                        var user = await graphClient.Me.Request().GetAsync();
                        string userId = user.Id;
                        
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Microsoft.Identity.Client.MsalException)
                {
                    return false;
                }
    
    
            }
    
        }
