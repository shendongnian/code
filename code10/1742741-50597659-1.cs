    with CTE AS (
      select distinct [Substation], [ColumnTitle],[S6_name], [AVNRString]
      from InfoTable T1
    )
    select T2.Substation,T2.ColumnTitle, T2.S6_name,T1.Pdate,T1.pTime,sum(T1.Wert) Sum_of_Wert
    from DataTable T1
    left join InfoTable T2 on  
      T2.AVNRString = T1.AVNR
      or T2.AVNRString like '%,'+T1.AVNR+'%'
      or T2.AVNRString like '%'+T1.AVNR+',%'
    group by T2.Substation,T2.ColumnTitle, T2.S6_name,T1.Pdate,T1.pTime
    order by Sum_of_Wert
