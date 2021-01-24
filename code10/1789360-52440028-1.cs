    [Test]
    public void DapperExpression()
    {
        // Arrange
        var id = 1;
        // Act
        var list = GetNotifs(uid => uid.U_Id == id);
        // Assert 
        Assert.IsNotEmpty(list);
    }
    public static List<Notification> GetNotifs(Expression<Func<Notification, bool>> p)
    {
        using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        {
            string sqlQ = "SELECT * FROM Notifications WHERE ";
            ParameterExpression param = p.Parameters[0];
            BinaryExpression operation = (BinaryExpression)p.Body;
            var t = operation.Left.GetType();
            MemberExpression left = (MemberExpression)operation.Left;
            sqlQ += left.Member.Name;
            MemberExpression right = (MemberExpression)operation.Right;
            ConstantExpression cnst = (ConstantExpression) right.Expression;
            var field = cnst.Type.GetFields().Single();
            var val = field.GetValue(cnst.Value);
            if (operation.NodeType.ToString() == "LessThan") sqlQ += " <";
            else if (operation.NodeType.ToString() == "GreaterThan") sqlQ += " >";
            else if (operation.NodeType.ToString() == "LessThanOrEqual") sqlQ += " <=";
            else if (operation.NodeType.ToString() == "GreaterThanOrEqual") sqlQ += " >=";
            else if (operation.NodeType.ToString() == "Equal") sqlQ += " =";
            else if (operation.NodeType.ToString() == "NotEqual") sqlQ += " !=";
            sqlQ += " " + val;
                
            return connection.Query<Notification>(sqlQ).ToList();
        }
    }
