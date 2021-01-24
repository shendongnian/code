`
// You will need the following namespaces:
// using System;
// using System.Data;
// using System.Data.SqlClient;
// using System.Windows.Forms;
var connectionString = "Your SQL Server connection string";
using (var con = new SqlConnection(connectionString))
{
    con.Open();
    var cmd = con.CreateCommand();
    cmd.CommandType = CommandType.Text;
    cmd.CommandText =
        "INSERT INTO Tbl_Attendance (Course, Subject, Year, Section, Name, Room, SeatNo, Status, Date) " +
        "VALUES (@Course, @Subject, @Year, @Section, @Name, @Room, @SeatNo, @Status, @Date)";
    var courseParam = cmd.Parameters.Add("@Course", SqlDbType.VarChar, 50);
    var subjectParam = cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 50);
    var yearParam = cmd.Parameters.Add("@Year", SqlDbType.VarChar, 50);
    var sectionParam = cmd.Parameters.Add("@Section", SqlDbType.VarChar, 50);
    var nameParam = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
    var roomParam = cmd.Parameters.Add("@Room", SqlDbType.VarChar, 50);
    var seatNoParam = cmd.Parameters.Add("@SeatNo", SqlDbType.VarChar, 50);
    var statusParam = cmd.Parameters.Add("@Status", SqlDbType.VarChar, 50);
    var dateParam = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
    dateParam.Value = DateTime.Now;
    foreach (DataGridViewRow row in dgEdit.Rows)
    {
        courseParam.Value = row.Cells[0].Value;
        subjectParam.Value = row.Cells[1].Value;
        yearParam.Value = row.Cells[2].Value;
        sectionParam.Value = row.Cells[3].Value;
        nameParam.Value = row.Cells[4].Value;
        roomParam.Value = row.Cells[5].Value;
        seatNoParam.Value = row.Cells[6].Value;
        statusParam.Value = row.Cells[7].Value;
        cmd.ExecuteNonQuery();
    }
}
MessageBox.Show("Updated! please check the report", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
`
Reason behind the changes:
 - When possible, instantiate and open your SqlConnection connection inside a
   `using` statement. This will ensure that your connection is always
   closed (disposed) when you are done with it in the scope.
 - Always use parameters in your queries when interacting with any external input.
   This will ensure that your code is not susceptible to SQL injection.
   As you can see, I added some parameters, but because you didn't
   provide your table schema I made then `VARCHAR(50)` with the
   exception of the `@Date` one where it's clear that you are saving a
   `System.DateTime`. Please feel free to change the `SqlDbType.VarChar`
   to the correct type where needed.
 - I moved the call to `MessageBox.Show` outside the `using` scope so it doesn't interfere with the connection disposal.
Another enhancement that you could do to this logic is implementing the use of the `System.Transactions.TransactionScope` class (you must add a reference to System.Transactions.dll), to ensure that if there's an error during any of the inserts, nothing gets `committed` to the database.
