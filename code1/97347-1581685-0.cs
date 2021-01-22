    using System;
    using System.Linq.Expressions;
    internal class TestContainer
    {
        public string LastName { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            var t = new TestContainer {LastName = "Hans"};            
            string s1 = BindingHelper<TestContainer>
                          .PropertyName(x => x.LastName);            
            string s2 = BindingHelper.PropertyName(t, x => x.LastName);
            string s3 = BindingHelper.PropertyName(() => t.LastName);
        }
    }
    internal static class BindingHelper
    {
        public static string PropertyName<TObject, TValue>(TObject template,
            Expression<Func<TObject, TValue>> propertySelector)
        {
            var memberExpression = propertySelector.Body as MemberExpression;
            if (memberExpression != null) return memberExpression.Member.Name;
            else
                throw new Exception("Something went wrong");
        }
        public static string PropertyName<TValue>(
             Expression<Func<TValue>> propertySelector)
        {
            var memberExpression = propertySelector.Body as MemberExpression;
            if (memberExpression != null) return memberExpression.Member.Name;
            else
                throw new Exception("Something went wrong");
        }
    }
    internal static class BindingHelper<TObject>
    {
        public static string PropertyName<TValue>(
            Expression<Func<TObject, TValue>> propertySelector)
        {
            var memberExpression = propertySelector.Body as MemberExpression;
            if (memberExpression != null) return memberExpression.Member.Name;
            else
                throw new Exception("Something went wrong");
        }
    }
