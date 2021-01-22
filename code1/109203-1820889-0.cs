    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace YourLibrary
    {
        public static class MyLinq
        {
            public static IEnumerable<T> Where<T>(
                this IMyDal<T> dal,
                Expression<Func<T, bool>> predicate)
            {
                BinaryExpression be = predicate.Body as BinaryExpression;
                var me = be.Left as MemberExpression;
                if(me == null) throw new InvalidOperationException("don't be silly");
                if(me.Expression != predicate.Parameters[0]) throw new InvalidOperationException("direct properties only, please!");
                string member = me.Member.Name;
                object value;
                switch (be.Right.NodeType)
                {
                    case ExpressionType.Constant:
                        value = ((ConstantExpression)be.Right).Value;
                        break;
                    case ExpressionType.MemberAccess:
                        var constMemberAccess = ((MemberExpression)be.Right);
                        var capture = ((ConstantExpression)constMemberAccess.Expression).Value;
                        switch (constMemberAccess.Member.MemberType)
                        {
                            case MemberTypes.Field:
                                value = ((FieldInfo)constMemberAccess.Member).GetValue(capture);
                                break;
                            case MemberTypes.Property:
                                value = ((PropertyInfo)constMemberAccess.Member).GetValue(capture, null);
                                break;
                            default:
                                throw new InvalidOperationException("simple captures only, please");
                        }
                        break;
                    default:
                        throw new InvalidOperationException("more complexity");
                }
                return dal.Find(member, value);
            }
        }
        public interface IMyDal<T>
        {
            IEnumerable<T> Find(string member, object value);
        }
    }
    namespace MyCode
    {
        using YourLibrary;
        static class Program
        {
            class Customer {
                public string Name { get; set; }
                public int Id { get; set; }
    
            }
            class CustomerDal : IMyDal<Customer>
            {
                public IEnumerable<Customer> Find(string member, object value)
                {
                    Console.WriteLine("Your code here: " + member + " = " + value);
                    return new Customer[0];
                }
            }
            static void Main()
            {
                var dal = new CustomerDal();
                var qry = from cust in dal
                          where cust.Name == "abc"
                          select cust;
    
                int id = int.Parse("123");
                var qry2 = from cust in dal
                          where cust.Id == id // capture
                          select cust;
    
    
            }
        }
    }
