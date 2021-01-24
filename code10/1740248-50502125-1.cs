    using ( dr = cmd.ExecuteReader())
    {
       while (dr.Read())
       {
          VO vo = new VO();
          vo.empname = dr["empname"].ToString();
          vo.deptname = dr["deptname"].ToString();
          
          emp1.emps.Add(vo);
       }
    }
