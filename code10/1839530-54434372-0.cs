    var webGet = new HtmlWeb();
            var getPage = webGet.Load("https://www.teamrankings.com/nba/stat/effective-field-goal-pct");
            var commentNode = getPage.DocumentNode.SelectNodes("//comment()[contains(.,'table-filters')]/following::*[not(preceding::comment()[contains(.,'main-wrapper')])]");
            var commentHtml = commentNode.Select(c1 => c1.SelectSingleNode("//table"));
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Rk", typeof(string));
            dataTable.Columns.Add("Team", typeof(string));
            dataTable.Columns.Add("2018", typeof(string));
            dataTable.Columns.Add("Last3", typeof(string));
            dataTable.Columns.Add("Last1", typeof(string));
            dataTable.Columns.Add("Home", typeof(string));
            dataTable.Columns.Add("Away", typeof(string));
            dataTable.Columns.Add("2017", typeof(string));
            foreach (var table in commentHtml)
            {
                foreach (var row in table.SelectNodes("//tr"))
                {
                    int i = 0;
                    var dr = dataTable.NewRow();
                    foreach (var cell in row.SelectNodes("//td"))
                    {
                        if (i <= 7)
                            dr[i++] = cell.InnerText;
                        else
                        {
                            i = 0;
                            dataTable.Rows.Add(dr);
                        }
                    }
                }
           gvTeamStats.DataSource = dt;
            }
