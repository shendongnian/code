`
CREATE TABLE dbo.MyTable
(
    MyColumn NVARCHAR(MAX)
)
`
And this logic will insert a record into the `dbo.MyTable` table with the text from `textbox1.Text`:
`
using (var cn = new SqlConnection("MyConnectionString"))
{
    cn.Open();
    using (var cm = cn.CreateCommand())
    {
        cm.CommandType = CommandType.Text;
        cm.CommandText = "INSERT dbo.MyTable (MyColumn) VALUES (@MyText)";
        // Assuming textBox1 is your textbox...
        cm.Parameters.Add(
            new SqlParameter("@MyText", SqlDbType.NVarChar, -1) { Value = textBox1.Text }
            );
        cm.ExecuteNonQuery();
    }
}
`
