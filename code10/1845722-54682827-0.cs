`C#
DynamicQueryBuilder sql = new DynamicQueryBuilder();
if(!list.Contains(2)) 
{ 
    sql.Append(@"SELECT TextBox1, TextBox2 FROM Table");
} 
else
{
    sql.Append(@"SELECT TextBox1, TextBox2, TextBox3 FROM Table");
}
`
