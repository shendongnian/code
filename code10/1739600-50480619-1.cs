    List<string> lp_list = new List<string>();
            lp_list.Add("import");
            lp_list.Add("automation");
            //lp_list contains a list of string values
            //string[] lp_labels = lp_list.ToArray();
            JObject issue_model = JObject.FromObject(new
            {
                labels = lp_list
            });
            
            Console.WriteLine(issue_model);
