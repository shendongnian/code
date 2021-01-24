    public static Task getSiteAsync(){
        var a = new Task(async () =>
        {
        back:
            String temp = "";
            var web = new HttpClient();
            string url = "Random Links from web uploaded from file";
            HttpResponseMessage data = await web.GetAsync(url);
            temp = data.RequestMessage.RequestUri.ToString();
            if (resources.Contains(temp) == false)
            {
                resources.Add(temp);//Add to list link
                Console.WriteLine(temp);
            }
            else
            {
                goto back;
            }
        });
        taskz.Add(a);
        a.Start();
        return a;
    }
