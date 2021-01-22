    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    class Foo
    {
        public string Bar { get; set; }
    }
    
    static class Program
    {
        static void Main()
        {
            Foo foo = new Foo {Bar = "abc"};
            Expression<Func<string>> func = () => foo.Bar;
    
            MemberExpression outerMember = (MemberExpression)func.Body;
            PropertyInfo outerProp = (PropertyInfo) outerMember.Member;
            MemberExpression innerMember = (MemberExpression)outerMember.Expression;
            FieldInfo innerField = (FieldInfo)innerMember.Member;
            ConstantExpression ce = (ConstantExpression) innerMember.Expression;
            object innerObj = ce.Value;
            object outerObj = innerField.GetValue(innerObj);
            string value = (string) outerProp.GetValue(outerObj, null);    
        }
    
    }
