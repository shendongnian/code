    Debug.Log(addTwo.Body); // (a + 2)
    Debug.Log(addTwo.Type); // Func<int, int>
    Debug.Log(addTwo.Body.NodeType); // Add
    Debug.Log(addTwo.Body is BinaryExpression); // True
    Debug.Log(((BinaryExpression)addTwo.Body).Left.NodeType); // Parameter
    Debug.Log(((BinaryExpression)addTwo.Body).Right.NodeType); // Constant
    Debug.Log(((ConstantExpression)((BinaryExpression)addTwo.Body).Right).Value); // 2
