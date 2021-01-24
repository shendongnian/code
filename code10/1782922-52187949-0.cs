        string description = "placeholder";
        string desc_mod;
        query.InnerHtml += "<table class='list_format'>";
        using (SqlDataReader productList = SQLHelper.ExecuteQuery(query1)) {
            if (productList.HasRows){
                {
                    while (productList.Read()) {
                        description = (string)productList["Description"];
                        desc_mod = description.Substring(0, 30);
                        query.InnerHtml += "<tr><td><div><p>" + desc_mod + "</p</div></td></tr>";
                    }
                }
            }
        }
        query.InnerHtml += "</table>";
