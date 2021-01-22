var base = ctx.WorkOrder.Where(w =&gt; w.WorkDate &gt;= StartDt && w.WorkDate &lt;= EndDt);
IQueryable&lt;WorkOrder&gt; query1;
if (showApprovedOnly)
{
  query1 = base.Where(w =&gt; w.IsApproved);
}
//more filters on query1
...
IQueryable&lt;WorkOrder&gt; query2;
if (/*something*/)
  query2 = base.Where(w =&gt; w.SomeThing);
