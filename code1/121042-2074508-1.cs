    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    namespace Test {
         class SomeType {
            public static void SomeMethod(object[] values) {
                foreach (var value in values) {
                    Console.WriteLine(value);
                }
            }
        }
        class Program {
            static Action<T> CreateAction<T>() {
                ParameterExpression parameter = Expression.Parameter(
                                                    typeof(T), 
                                                    "parameter"
                                                );
                List<Expression> properties = new List<Expression>();
                foreach (var info in typeof(T).GetProperties()) {
                    Expression property = Expression.Property(parameter, info);
                    properties.Add(Expression.Convert(property, typeof(object)));
                }
                
                Expression call = Expression.Call(
                     typeof(SomeType).GetMethod("SomeMethod"),
                     Expression.NewArrayInit(typeof(object), properties)
                );
                return Expression.Lambda<Action<T>>(call, parameter).Compile();
            }
            static void Main(string[] args) {
                Customer c = new Customer();
                c.Name = "Alice";
                c.ID = 1;
                CreateAction<Customer>()(c);
            }
        }
        class Customer {
            public string Name { get; set; }
            public int ID { get; set; }
        }
    }
