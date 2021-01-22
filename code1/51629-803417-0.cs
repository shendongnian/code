    public static void PFA(Expression<Action<frmain>> expression) {
        // this will give you form.RichTextBox1
        var targetFormProperty = (MemberAccessExpression)expression.Body;
        // this only works for your example given. this gives you RichTextBox1.Text
        var textProperty = (MemberAccessExpression)targetFormProperty.Expression;
        // this is how you would run your action like normal
        var action = expression.Compile();
        action(); // invoke action (you would want to wrap this in the invoke check)
    }
