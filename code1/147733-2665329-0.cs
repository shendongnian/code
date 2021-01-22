    using(SqlConnection con = new SqlConnection(......))
    {
       string stmt = 
          "declare @nod hierarchyid; " + 
          "select @nod = DepartmentHierarchyNode from Organisation where DepartmentHierarchyNode = 0x6BDA; " + 
          "select * from Organisation where @nod.IsDescendantOf(DepartmentHierarchyNode) = 1";
       using(SqlCommand cmd = new SqlCommand(stmt, con))
       {
          con.Open();
          using(SqlDataReader rdr = cmd.ExecuteReader())
          {
             // here, read your values back
          }
          con.Close();
       }
    }
