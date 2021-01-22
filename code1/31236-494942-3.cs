public IEnumerable&lt;Employee&gt; All(int accountholder_id)
{
    return db.Employees.Where(e =&gt; e.accountholder_id == accountholder_id)
        .OrderBy(a =&gt; a.name);
}
public Employee Single(int id)
{
    return db.Employees.Single(a =&gt; a.id == id);
}
<p>So - can you clarify what the cAccountEntity does here?</p>
