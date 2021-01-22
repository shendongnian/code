    public static Func<T, KeyValuePair<Expression<Func<Task, T>>, T> >
        Marry<T>(
            Expression<Func<Task, T>> key) {
        return (value=>new KeyValuePair<Expression<Func<Task, T>>, T>(key, value));
    }
    //usage:
    Marry(t => t.NULLABLEDATETIME)("test"); 
    //error: Delegate 'System.Func<System.DateTime?,System.Collections.Generic.KeyValuePair<System.Linq.Expressions.Expression<System.Func<UserQuery.Task,System.DateTime?>>,System.DateTime?>>' has some invalid arguments
    //  - Argument 1: cannot convert from 'string' to 'System.DateTime?'
