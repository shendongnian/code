    public static IQueryable<object> SearchBySecurityList(List<SecurityListFilter> caSecurityFilterList, IQueryable<object> qry, string companySearch, string fpSearch, string poSearch, string controlOwnerSearch, string carSearch)
        {
            string whereClause = "";
            int paramCount = -1;
            int loopCount = 1;
            PropertyInfo[] props = qry.GetType().GetProperties();
            List<string> paramList = new List<string>();
            List<string> finalList = new List<string>();
            foreach (var i in caSecurityFilterList)
            {
                if (loopCount > 1)
                {
                    whereClause = whereClause + " || ";
                }
                string innerWhere = "(";
                if (!string.IsNullOrWhiteSpace(i.CompanyName))
                {
                    if(!props.HasProperty("Company") || !props.HasProperty("CompanyName"))
                    {
                        paramList.Add(i.CompanyName);
                        paramCount++;
                        innerWhere = innerWhere + $"{companySearch} == @{paramCount}";
                    }
                }
                if (!string.IsNullOrWhiteSpace(i.BlahProcessName))
                {
                    if (!props.HasProperty("BlahProcess") || !props.HasProperty("BlahProcessName"))
                    {
                        paramList.Add(i.BlahProcessName);
                        paramCount++;
                        if (innerWhere.Length > 1) innerWhere = innerWhere + " and ";
                        innerWhere = innerWhere + $"{fpSearch} == @{paramCount}";
                    }
                }
                if (!string.IsNullOrWhiteSpace(i.ProcessOwner))
                {
                    if (!props.HasProperty("ProcessOwner"))
                    {
                        paramList.Add(i.ProcessOwner);
                        paramCount++;
                        if (innerWhere.Length > 1) innerWhere = innerWhere + " and ";
                        innerWhere = innerWhere + $"{poSearch} == @{paramCount}";
                    }
                }
                if (!string.IsNullOrWhiteSpace(i.ControlOwner))
                {
                    if (!props.HasProperty("ControlOwner"))
                    {
                        paramList.Add(i.ControlOwner);
                        paramCount++;
                        if (innerWhere.Length > 1) innerWhere = innerWhere + " and ";
                        innerWhere = innerWhere + $"{controlOwnerSearch} == @{paramCount}";
                    }
                }
                if (!string.IsNullOrWhiteSpace(i.CAR))
                {
                    if (!props.HasProperty("BLAH"))
                    {
                        paramList.Add(i.CAR);
                        paramCount++;
                        if (innerWhere.Length > 1) innerWhere = innerWhere + " and ";
                        innerWhere = innerWhere + $"{carSearch} == @{paramCount}";
                    }
                }
                innerWhere = innerWhere + ")";
                whereClause = whereClause + innerWhere;//This should get me something like "() || () || ()"
                loopCount++;
            }
            return qry.Where(whereClause, paramList.ToArray());
        }
