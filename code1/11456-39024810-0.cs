    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    ...
    bool isMatch = LikeOperator.LikeString("I love .NET!", "I love *", CompareMethod.Text);
    // isMatch should be true.
