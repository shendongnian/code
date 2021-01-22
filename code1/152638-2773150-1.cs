    select 'updated',
       a.IssueID as IssueID_A, b.IssueID as IssueID_B
       a.Status as Status_A, b.Status as Status_B,
       a.Who as Who_A, b.Who as Who_B
    from tablea a
    inner join tableb b 
       on a.IssueID = b.IssueID 
    where a.Status <> b.Status or a.Who <> b.Who
