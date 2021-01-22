        Collection<smsPart> list = new Collection<smsPart>();
        Dictionary<int, smsPart> dic = new Dictionary<int, smsPart>();
        using (conn)
        {
            conn.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                smsPart xPart = new smsPart();
                xPart.ID = int.Parse(dr["ID"].ToString());
                if (!string.IsNullOrEmpty(dr["Parent"].ToString()))
                    xPart.ParentID = int.Parse(dr["Parent"].ToString());
                xPart.Name = dr["Name"].ToString();
                dic.Add(xPart.ID, xPart);
            }
        }
        foreach (smsPart childPart in dic.Values)
        {
            if (childPart.ParentID > 0)
            {
                childPart.Parent = dic[childPart.ParentID];
            }
            list.Add(childPart);
        }
        return list;
