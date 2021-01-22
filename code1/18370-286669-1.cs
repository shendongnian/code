    static class MemberUtil<TType>
    {
        public static string MemberName<TResult>(Expression<Func<TType, TResult>> member)
        {
            return MemberUtil.MemberName<TType, TResult>(member);
        }
    }
