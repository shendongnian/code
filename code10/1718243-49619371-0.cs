return @@identity? any ways...I will modify your stored procedure as..
    CREATE PROCEDURE [dbo].[sproc_tblUser_GetAllInfo](
    	@Email NCHAR (25),
    	@UserID Int
    ) AS
    BEGIN
    	SELECT tblUser.Firstname, tblUser.Lastname, tblPersonal.Age, tblPersonal.Sex
    	FROM tblUser
    	LEFT OUTER JOIN tblPersonal
    	ON   tblUser.UserID = tblPersonal.UserID
    	WHERE tblUser.UserID = @UserID
    RETURN 0
    END
and .net code if condition as, get rid of else
    if (db.Count >= 1)
    {
        //get parameters
        User.ThisID.Firstname = Convert.ToString(db.DataTable.Rows[0]["Firstname"]);
        User.ThisID.Lastname = Convert.ToString(db.DataTable.Rows[0]["Lastname"]);
    //send to text boxes
    txtName.Text = string.Format("{0} {1}", User.ThisID.Firstname, User.ThisID.Lastname);
    if (!string.IsNullOrEmpty(db.DataTable.Rows[0]["Sex"]))
    {
        User.ThisID.Sex = Convert.ToString(db.DataTable.Rows[0]["Sex"]);
        txtSex.Text = Convert.ToString(User.ThisID.Sex);
    }
    if (!string.IsNullOrEmpty(db.DataTable.Rows[0]["Age"]))
    {
        User.ThisID.Age = Convert.ToInt32(db.DataTable.Rows[0]["Age"]);
        txtAge.Text = Convert.ToString(User.ThisID.Age);
    }
    }
