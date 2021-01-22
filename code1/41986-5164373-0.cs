    public  static class ControlExtension
    {
        delegate void SetPropertyValueHandler<TResult>(Control souce, Expression<Func<Control, TResult>> selector, TResult value);
        public static void SetPropertyValue<TResult>(this Control source, Expression<Func<Control, TResult>> selector, TResult value) 
        {
            if (source.InvokeRequired)
            {
                var del = new SetPropertyValueHandler<TResult>(SetPropertyValue);
                source.Invoke(del, new object[]{ source, selector, value});
            }
            else
            {
                var propInfo = ((MemberExpression)selector.Body).Member as PropertyInfo;
                propInfo.SetValue(source, value, null);
            }
        }
    }
