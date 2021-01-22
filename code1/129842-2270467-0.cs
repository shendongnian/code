    public class Student
    {
        public int Grade { get; set; }
        public string TheNameOfTheGradeProperty
        {
            get
            {
                Expression<Func<int>> gradeExpr = () => this.Grade;
                MemberExpression body = gradeExpr.Body as MemberExpression;
                return body.Member.Name;
            }
        }
    }
