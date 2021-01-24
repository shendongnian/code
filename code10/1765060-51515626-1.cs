            //Case 1: Category
            var caretoryResult = dt.AsEnumerable().GroupBy(category => category.Field<string>("Category")).ToList();
            foreach (var item in caretoryResult)
            {
                var getType = dt.AsEnumerable().Where(type => type.Field<string>("Category").Trim() == item.Key.ToString().Trim());
                dtNew.Rows.Add("", "", "");
                string[] strType = new string[getType.ToList().Count];
                int b = 0;
                getType.ToList().ForEach(row => { 
                    dtNew.Rows[dtNew.Rows.Count - 1]["Id"] += row.Field<string>("Id").Trim() + ",";
                    strType[b++] = row.Field<string>("Type").Trim();
                });
                dtNew.Rows[dtNew.Rows.Count - 1]["Category"] = item.Key.ToString().Trim();
                dtNew.Rows[dtNew.Rows.Count - 1]["Type"] = strType.ToList().GroupBy(type => type).ToList().Count > 1 ? "" : strType[0].Trim();
            }
