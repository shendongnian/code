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
UPDATE
------
Based on your comment below, I made the following changes to your code around the `SqlCommand` to use parameters instead of string concatenation, I explained why this is bad [here][1]; The code below will save your unicode text into your table as expected and will be safe:
SqlCommand ins = new SqlCommand("UPDATE ProductTestSpecifications set Specification = @Specification where ProductID = @ProductID and TestID = @TestID", con);
// When building your SqlCommand, always use parameters if you are interacting with external input, this will protect you against SQL injection.
ins.Parameters.Add("@Specification", SqlDbType.NVarChar, -1).Value = myRichText.Text;
// Im assuming ProductID and TestID are System.Int32, if not, please change SqlDbType.Int to the appropriate type.
ins.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
ins.Parameters.Add("@TestID", SqlDbType.Int).Value = TestID;
try
{
    ins.ExecuteNonQuery();
}
catch (Exception ex)
{
    result = ex.Message.ToString();
}
  [1]: https://stackoverflow.com/questions/54502151/is-there-a-way-to-make-this-code-insert-all-the-current-data-in-the-database/54507195#54507195
